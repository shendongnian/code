    public class DefaultOrderFieldAttribute : Attribute
    {
        public DefaultOrderFieldAttribute()
        {
        }
     
        public string FieldName { get; set; }
    }
     
    [DefaultOrderField(FieldName = "ParameterName")]
    public partial class Parameter
    {
    }
