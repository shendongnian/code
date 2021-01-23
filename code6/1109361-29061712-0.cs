    private List<CheckBox> FindCheckControls<T>(Control control, bool recurse)
        {
            List<CheckBox> found = new List<CheckBox>();
            Action<Control> search = null;
            search = ctrl =>
            {
                foreach (Control child in ctrl.Controls)
                {
                    if (typeof(CheckBox).IsAssignableFrom(child.GetType()))
                    {
                        found.Add((CheckBox)child);
                    }
                    if (recurse)
                    {
                        search(child);
                    }
                }
            };
            search(control);
            return found;
        }
