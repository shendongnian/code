    public class JsonWriter
    {
        private readonly IFileSystem _file;
        private readonly HttpContextBase _httpContext;
        private readonly ILog _logger;
        public JsonWriter(
            IFileSystem file, 
            HttpContextBase httpContext,
            ILog logger)
        {
            _file = file;
            _httpContext = httpContext;
            _logger = logger;
        }
        public bool WriteFile<T>(string fileName, IEnumerable<T> list)
        {
            try
            {
                var listContent = JsonConvert.SerializeObject(list, Formatting.Indented);
                _file.WriteAllText(_httpContext.Server.MapPath(fileName), listContent);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return false;
            }
        }
    }
