    public static class EmployeeHelper {
       public static Employee LoggedIn {
          get { return HttpContext.Current.Session["LoggedInEmployee"] as Employee; }
       }
    }
