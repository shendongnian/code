        protected void Page_Load(object sender, EventArgs e)
        {
           if ( Request["filename"] != null)
           {
               string FilePath = MapPath(Request["filename"]);
               long fSize = (new System.IO.FileInfo(FilePath)).Length;
               long startbyte = 0;
               long endbyte=fSize-1;
               int statusCode =200;
               if ((Request.Headers["Range"] != null))
               {
                   //Get the actual byte range from the range header string, and set the starting byte.
                   string[] range = Request.Headers["Range"].Split(new char[] {	'=','-'});
                   startbyte = Convert.ToInt64(range[1]);
                   if (range.Length >2 && range[2]!="")  endbyte =  Convert.ToInt64(range[2]);
                   //If the start byte is not equal to zero, that means the user is requesting partial content.
                   if (startbyte != 0 || endbyte != fSize - 1 || range.Length > 2 && range[2] == "")
                   {statusCode = 206;}//Set the status code of the response to 206 (Partial Content) and add a content range header.                                    
               }
               long desSize = endbyte - startbyte + 1;
               //Headers
               Response.StatusCode = statusCode;
               Response.ContentType = "audio/mp3";
               Response.AddHeader("Content-Length",desSize.ToString()); 
               Response.AddHeader("Content-Range", string.Format("bytes {0}-{1}/{2}", startbyte, endbyte , fSize));
               //Data
               Response.WriteFile(FilePath,startbyte,desSize);
               Response.End(); 
           };      
        }
    
