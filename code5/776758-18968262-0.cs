    public class ExtendedController : Controller
    {
        public T TryCreateModelFromJson<T>(string requestFormKey)
        {
            if (!this.Request.Form.AllKeys.Contains(requestFormKey))
            {
                throw new ArgumentException("Request form doesn't contain provided key.");
            }
            return
                JsonConvert.DeserializeObject<T>(
                    this.Request.Form[requestFormKey]);
        }
    }
