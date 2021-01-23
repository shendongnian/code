    public class RowHelper
    {
        public static Row<object> LoadRow(object o)
        {
            var type = o.GetType();
            return new Row<object>
            {
                Name = (string)type.InvokeMember("Name", BindingFlags.GetProperty, null, o, null),
                Value = type.InvokeMember("Value", BindingFlags.GetProperty, null, o, null)
            };
        }
    }
