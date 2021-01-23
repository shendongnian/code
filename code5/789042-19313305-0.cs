        public static Control FindControlRecursive(Control control, string id)
        {
            if (control == null) return null;
            Control c = control.FindControl(id);
            if (c == null)
            {
                foreach (Control child in control.Controls)
                {
                    c = FindControlRecursive(child, id);
                    if (c != null) break;
                }
            }
            return c;
        }
