    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Xml;
    using MyDatabase;
    
    namespace MyWebApplication
    {
        public class MemberHandler : IHttpHandler
        {
    
            public void ProcessRequest(HttpContext context)
            {
                Member requestedMember = null;
                Exception error = null;
    
                try
                {
                    requestedMember = MyDatabaseClient.GetMemberByID(int.Parse(context.Request.QueryString["id"]));
                }
                catch (Exception ex)
                {
                    error = ex;
                }
    
                context.Response.ContentType = "text/xml";
                context.Response.ContentEncoding = Encoding.UTF8;
    
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(context.Response.OutputStream, Encoding.UTF8) { Formatting = Formatting.Indented })
                {
                    xmlTextWriter.WriteStartDocument();
                    if (requestedMember != null)
                    {
                        xmlTextWriter.WriteStartElement("member");
    
                        xmlTextWriter.WriteStartElement("id");
                        xmlTextWriter.WriteValue(requestedMember.ID);
                        xmlTextWriter.WriteEndElement();
    
                        xmlTextWriter.WriteStartElement("name");
                        xmlTextWriter.WriteValue(requestedMember.Name);
                        xmlTextWriter.WriteEndElement();
    
                        xmlTextWriter.WriteStartElement("dob");
                        xmlTextWriter.WriteValue(requestedMember.DOB);
                        xmlTextWriter.WriteEndElement();
    
                        xmlTextWriter.WriteEndElement();
                    }
                    else
                    {
                        xmlTextWriter.WriteStartElement("error");
                        xmlTextWriter.WriteValue(error.Message);
                        xmlTextWriter.WriteEndElement();
                    }
                }
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
