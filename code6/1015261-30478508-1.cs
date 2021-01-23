    public class CSVMediaTypeFormatter : MediaTypeFormatter {
    
        public CSVMediaTypeFormatter() {
    
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }
        
        public CSVMediaTypeFormatter(
            MediaTypeMapping mediaTypeMapping) : this() {
    
            MediaTypeMappings.Add(mediaTypeMapping);
        }
        
        public CSVMediaTypeFormatter(
            IEnumerable<MediaTypeMapping> mediaTypeMappings) : this() {
    
            foreach (var mediaTypeMapping in mediaTypeMappings) {
                MediaTypeMappings.Add(mediaTypeMapping);
            }
        }
    }
