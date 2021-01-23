    public class Global : HttpApplication
    {
        private static Container container;
        public static void InitializeHandler(IHttpHandler handler)
        {
            if (handler is Page)
            {
                Global.InitiaizePage((Page)handler);
            }
        }
        private static void InitiaizePage(Page page)
        {
            container.GetRegistration(page.GetType(), true).Registration
                .InitializeInstance(page);
            page.InitComplete += delegate { Global.InitiaizeControl(page); };
        }
        private static void InitiaizeControl(Control control)
        {
            if (control is UserControl)
            {
                container.GetRegistration(control.GetType(), true).Registration
                    .InitializeInstance(control);
            }
            foreach (Control child in control.Controls)
            {
                Global.InitiaizeControl(child);
            }
        }
