    public class CmsFilterStream : MemoryStream {
    
        private Stream        _responseStream;  
        
        public CmsFilterStream( Stream inputStream ) {
            _responseStream = inputStream;
        }
        
        public override void Close() {
            var allHtml = UTF8Encoding.UTF8.GetString(this.ToArray()); // get ALL bytes!!
            allHtml = allHtml.Replace("THE_PLACEHOLDER", "SOME_HTML");
            
            var buf =UTF8Encoding.UTF8.GetBytes(allHtml);
            _responseStream.Write(buf,0, buf.Length);
            
            _responseStream.Flush(); // I assume the caller will close the _responseStream
            
            base.Close();
        }
    }
