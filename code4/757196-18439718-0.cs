    public static class SessionManager
    {
        public static List<Entity.Permission> GetUserPermission
        {
            get
            {
                if (HttpContext.Current.Session["GetUserPermission"] == null)
                {
                    //if session is null than set it to default value
                    //here i set it 
                    List<Entity.Permission> lstPermission = new List<Entity.Permission>();
                    HttpContext.Current.Session["GetUserPermission"] = lstPermission;
                }
                return (List<Entity.Permission>)HttpContext.Current.Session["GetUserPermission"];
            }
            set
            {
                HttpContext.Current.Session["GetUserPermission"] = value;
            }
        }
     }
