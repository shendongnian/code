        protected void Page_Load(object sender, EventArgs e)
        {
            ImageButton imgButton = FindControl<ImageButton>("imgBtn1", this);
        }
        public T FindControl<T>(string name, Control current) where T : System.Web.UI.Control
        {
            if (current.ID == name && current is T) return (T)current;
            foreach (Control control in current.Controls)
            {
                if (control.ID == name && control is T)
                {
                    return (T)control;
                }
                foreach (Control child in control.Controls)
                {
                    var ctrl = FindControl<T>(name, child);
                    if (ctrl != null && ctrl.ID == name) return ctrl;
                }
            }
            return default(T);
        }
