    public class RequestService : IRequestService {
    
        public string GetFormValue(string key) {
            return HttpContext.Current.Request.Form[key];
        }
        
        public HttpPostedFile GetFile(int index) {
            return HttpContext.Current.Request.Files[index];
        }
    }
