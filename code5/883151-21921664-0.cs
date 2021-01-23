    public class EmployeePhotoHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }
        public void ProcessRequest(HttpContext context)
        {
            int employeeID;
            if (!int.TryParse(context.Request.QueryString["ID"], out employeeID))
                return;
            EmployeePhoto photo = EmployeeService.GetPhotoByEmployee(EmployeeService.GetEmployeeByID(employeeID));
            if (photo == null || photo.Photo == null)
                return;
            context.Response.ContentType = "image/jpeg";
            context.Response.BinaryWrite(photo.Photo);
        }
    }
