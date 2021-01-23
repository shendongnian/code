    public static class Methods
    {
        public static IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (Control descendant in GetAllControls(control))
                {
                    yield return descendant;
                }
            }
        }
    }
    var securedControls = Helpers.Methods.GetAllControls(this)
                                          .OfType<WebControl>()
                                          .Where(c => c.CssClass == "box2 ");
