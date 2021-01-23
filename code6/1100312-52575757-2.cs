    public class JsonBinder<T> : System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            using (var reader = new System.IO.StreamReader(controllerContext.HttpContext.Request.InputStream))
            {
                //set stream position 0, maybe previous action already read the stream.
                controllerContext.HttpContext.Request.InputStream.Position = 0;
                string json = reader.ReadToEnd();
                if (string.IsNullOrEmpty(json) == false)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    object jsonData = serializer.DeserializeObject(json);
                    return serializer.Deserialize<T>(json);
                }
                else
                {
                    return null;
                }
            }
        }
    }
