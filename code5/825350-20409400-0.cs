    <%@ WebHandler Language="C#" Class="Watch" %>
    using System;
    using System.Globalization;
    using System.IO;
    using System.Web;
    
    public class Watch : IHttpHandler {
    
        public void ProcessRequest(HttpContext context)
        {
            // Get the VideoID from the requests `v` parameters.
            var videoId = context.Request.QueryString["v"];
            
    		/* With the videoId you'll need to retrieve the filepath 
    		/  from the database. You'll need to replace the method 
    		/  below with your own depending on whichever
    		/  DBMS you decide to work with.
    		*////////////////////////////////////////////////////////
    		var videoPath = DataBase.GetVideoPath(videoId);
    		
    		// This method will stream the video.
    		this.RangeDownload(videoPath, context);
        }
    
        
    	private void RangeDownload(string fullpath, HttpContext context)
        {
            long size;
            long start;
            long theend;
            long length;
            long fp = 0;
            using (StreamReader reader = new StreamReader(fullpath))
            {
                size = reader.BaseStream.Length;
                start = 0;
                theend = size - 1;
                length = size;
    
                context.Response.AddHeader("Accept-Ranges", "0-" + size);
    
                if (!string.IsNullOrEmpty(context.Request.ServerVariables["HTTP_RANGE"]))
                {
                    long anotherStart;
                    long anotherEnd = theend;
                    string[] arrSplit = context.Request.ServerVariables["HTTP_RANGE"].Split('=');
                    string range = arrSplit[1];
    
                    if ((range.IndexOf(",", StringComparison.Ordinal) > -1))
                    {
                        context.Response.AddHeader("Content-Range", "bytes " + start + "-" + theend + "/" + size);
                        throw new HttpException(416, "Requested Range Not Satisfiable");
                    }
    
                    if ((range.StartsWith("-")))
                    {
                        anotherStart = size - Convert.ToInt64(range.Substring(1));
                    }
                    else
                    {
                        arrSplit = range.Split('-');
                        anotherStart = Convert.ToInt64(arrSplit[0]);
                        long temp;
                        if ((arrSplit.Length > 1 && Int64.TryParse(arrSplit[1], out temp)))
                        {
                            anotherEnd = Convert.ToInt64(arrSplit[1]);
                        }
                        else
                        {
                            anotherEnd = size;
                        }
                    }
    
                    anotherEnd = (anotherEnd > theend) ? theend : anotherEnd;
    
                    if ((anotherStart > anotherEnd | anotherStart > size - 1 | anotherEnd >= size))
                    {
                        context.Response.AddHeader("Content-Range", "bytes " + start + "-" + theend + "/" + size);
                        throw new HttpException(416, "Requested Range Not Satisfiable");
                    }
    
                    start = anotherStart;
                    theend = anotherEnd;
    
                    length = theend - start + 1;
    
                    fp = reader.BaseStream.Seek(start, SeekOrigin.Begin);
                    context.Response.StatusCode = 206;
                }
            }
    
            context.Response.ContentType = "video/mp4";
            context.Response.AddHeader("Content-Range", "bytes " + start + "-" + theend + "/" + size);
            context.Response.AddHeader("Content-Length", length.ToString(CultureInfo.InvariantCulture));
    
            context.Response.TransmitFile(fullpath, fp, length);
            context.Response.End();
        }
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    
    }
