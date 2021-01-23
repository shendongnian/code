    public class MyApp
    {
        public static Form MdiForm
        {
            get {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.IsMdiContainer)
                        return frm;
                }
                return null;
            }
        }
    }
