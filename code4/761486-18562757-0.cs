    public class Response
    {
        public bool Success { get; private set; }
        public static T CreateErrorResponse<T>() where T : Response, new()
        {
            var response = new T();
            response.Success = false;
            return response;
        }
    }
