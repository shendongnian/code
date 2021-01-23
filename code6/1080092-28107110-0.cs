    public class PropertyEmptySetter
    {
        public PropertyEmptySetter()
        {
            UpdateStringProperties();
        }
        public void UpdateStringProperties()
        {
            foreach (var prop in obj.GetType().GetProperties().ToList())
            {
                if (prop.PropertyType == (typeof(string)))
                {
                    if (prop.GetValue(obj) == null)
                        prop.SetValue(obj, String.Empty);
                }
            }
        }
    }
    class POCO : PropertyEmptySetter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Purpose { get; set; }
    }
