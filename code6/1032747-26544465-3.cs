    public class CustomEditor : System.Drawing.Design.UITypeEditor
    {
       public override object EditValue(
	       ITypeDescriptorContext context,
	       IServiceProvider provider,
	       object value)
       {
           var property = context.PropertyDescriptor;
           var config = (MyConfigAttribute)
               property.Attributes[typeof(MyConfigAttribute)];
           // ...
       }
 
    }
