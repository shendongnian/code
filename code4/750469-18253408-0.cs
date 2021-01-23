    public static class ControlExtensions
    {
        public static IEnumerable<Control> GetEnumerableChildren(this Control control)
        {
            return control.Controls.Cast<Control>();
        }
        public static Control FindAny(this Control control, string id)
        {
            var result = control.GetEnumerableChildren().FirstOrDefault(c => c.ID == id);
            if (result != null)
                return result;
            return control.GetEnumerableChildren().Select(child => child.FindAny(id)).FirstOrDefault();
        }
    }
