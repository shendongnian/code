    public class Global : HttpApplication
    {
        private static Container container;
        public static void InitializeHandler(IHttpHandler handler)
        {
            if (handler is Page)
            {
                Global.InitializePage((Page)handler);
            }
        }
        private static void InitializePage(Page page)
        {
            container.GetRegistration(page.GetType(), true).Registration
                .InitializeInstance(page);
            page.InitComplete += delegate { Global.InitializeControl(page); };
        }
        private static void InitializeControl(Control control)
        {
            if (control is UserControl)
            {
                container.GetRegistration(control.GetType(), true).Registration
                    .InitializeInstance(control);
            }
            foreach (Control child in control.Controls)
            {
                Global.InitializeControl(child);
            }
        }
