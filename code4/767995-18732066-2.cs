    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Web;
    
    namespace WebApplication1
    {
        /// <summary>
        /// Summary description for viewImage
        /// </summary>
        public class viewImage : IHttpHandler
        {
            /// <summary>
            /// process the request
            /// </summary>
            /// <param name="context">the current request handler</param>
            public void ProcessRequest(HttpContext context)
            {
                ///extract our params from the request
                int memberID = 0, imageID = 0;
                if (!int.TryParse(context.Request["memberreportid"], out memberID) || 
                     memberID <= 0 ||
                     !int.TryParse(context.Request["imageID"], out imageID) || 
                     imageID <= 0)
                {
                    this.transmitError();
                    return;
                }
    
                //build our query
                var query = string.Format("SELECT TOP 1 image{0} FROM  MemberReport where memberreportid=@p1", imageID);
    
                //execute the query
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
                {
                    try
                    {
                        var cmd = new SqlCommand(query, con);
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandTimeout = 3000;
                        //set the member command type
                        cmd.Parameters.AddWithValue("@p1", memberID);
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string psudoFileName = string.Format("memberReport_{0}_image{1}.png", memberID, imageID);
                            byte[] binary = reader[0] as byte[];
                            context.Response.ContentType = "image/png";
                            context.Response.AppendHeader("Content-Disposition", string.Format("filename=\"{0}\"", psudoFileName));
                            context.Response.AppendHeader("Content-Length", binary.Length.ToString());
                            context.Response.BinaryWrite(binary);
    
                            //todo: Implement your caching. we will use no caching
                            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
    
                            //we only want the first row so break (should never happen anyway)
                            break;
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        //TODO: Maybe some logging?
                        
                    }
                    this.transmitError();   
                }
            }
            
            /// <summary>
            /// transmits a non-image found
            /// </summary>
            void transmitError()
            {
                var context = HttpContext.Current;
                if (context == null)
                    return;
                //set the response type
                context.Response.ContentType = "image/png";
                //set as no-cache incase this image path works in the future.
                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
    
                //transmit the no-image found error
                context.Response.TransmitFile(context.Server.MapPath("no-image.png"));
            }
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
    }
