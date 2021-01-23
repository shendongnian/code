    public static class FormExtensions
    {
        public static void ChangeAll<T>(this Form form, string propName, object value) where T : Control
        {
            foreach (Control c in form.Controls.OfType<T>())
            {
                PropertyInfo myPropInfo = typeof(T).GetProperty(propName);
                if (myPropInfo != null)
                {
                    myPropInfo.SetValue(c, value, null);
                }
            }
        }
    }
