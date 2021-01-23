    public class CanViewAttribute : RequestFilterAttribute {
        private readonly string permission;
        public CanViewAttribute(string permission) {
            this.permission = permission;
        }
        public override void Execute(IHttpRequest req, IHttpResponse res, object responseDto) {
            // todo: check permission
        
            if (!hasPermission) {
              res.StatusCode = (int)HttpStatusCode.Forbidden;
              res.EndRequest();
            }
        }
    }
