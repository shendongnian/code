    public class RequestService : IRequestService {
    
        public string GetFormValue(string key) {
            return HttpContext.Current.Request.Form[key];
        }
        
        public HttpPostedFileBase GetFile(int index) {
            return new HttpPostedFileWrapper(HttpContext.Current.Request.Files[index]);
        }
    }
