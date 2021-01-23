    namespace PS.Web.Pages.Maintenance.Area.Display
    {
        public static class DisplayArea
        {
            public static string URL = "/Pages/Maintenance/Area/Display/DisplayArea.aspx";
    
            public static string Show(System.Int32 areaId)
            {
                return string.Format("{0}?PageMethod=Show&areaId={1}", URL, areaId);
            }
        }
    }
