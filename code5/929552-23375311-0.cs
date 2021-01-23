    public class TestObject : iTestObject 
    {
        // Declare fields
        [FieldAttr("prop_testfld1")]
        public FLDtype1 testfld1 = new FLDtype1();
    
        [FieldAttr("prop_testfld2")]
        public FLDtype2 testfld2 = new FLDtype2();
    
        [FieldAttr("prop_testfld3")]
        public FLDtype1 testfld3;
    }
    
    public class FLDtype1 : iField
    {
        public string Value { get; set; }
    }
    
    public class FLDtype2 : iField
    {
        public Guid Value { get; set; }
    }
    
    public sealed class FieldAttr: System.Attribute
    {
        private string _txt;
    
        public FieldAttr(string txt)
        {
            this._txt = txt;
        }
    
        public string Text { get { return this._txt; } }
    }
    
    public interface iField { }
    public interface iTestObject { }
    
    public static class Extensions
    {
        public static FieldAttr GetFieldAttr<T>(this T source, Expression<Func<iField>> field) where T : iTestObject 
        {
            // Get member body. If no body present, return null
            MemberExpression member = (MemberExpression)field.Body;
            if (member == null) { return null; }
    
            // Get field info. If no field info present, return null
            FieldInfo fieldType = typeof(T).GetField(member.Member.Name);
            if (fieldType == null) { return null; }
    
            // Return custom attribute
            return fieldType.GetCustomAttribute<FieldAttr>();
        }
    }
