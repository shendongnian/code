    public static class EmployeeHelper {
       // ===== Bad approach =====
       private static HttpSessionState _session = HttpContext.Current.Session;
       public static Employee LoggedIn {
          get { return _session["LoggedInEmployee"] as Employee; }
       }
    }
