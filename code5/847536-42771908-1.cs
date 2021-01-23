    public class JsonNetResult : JsonResult
    {
        public int ContentLength { get; private set; }
        public JsonNetResult()
        {
            this.ContentLength = 0;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(base.ContentType)
                ? base.ContentType
                : "application/json";
            var serializedObject = JsonConvert.SerializeObject(base.Data, Formatting.None);
            if (base.ContentEncoding != null)
            {
                response.ContentEncoding = base.ContentEncoding;
                this.ContentLength = response.ContentEncoding.GetByteCount(serializedObject);
            }
            else
            {
                this.ContentLength = Encoding.UTF8.GetByteCount(serializedObject);
            }
            response.Write(serializedObject);
        }
    }
