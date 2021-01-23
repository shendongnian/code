    public Form1()
    {
        InitializeComponent();
    
        DynamicTypeDescriptor dt = new DynamicTypeDescriptor(typeof(MyBeautifulClass));
    
        MyBeautifulClass c = new MyBeautifulClass(); // initialize the class the way you want    
        if (some condition)
        {
            dt.RemoveProperty("PropertyIWantToHide");
        }
        if (some other condition)
        {
            // replace property by another version
            dt.RemoveProperty("PropertyIWantToHide");
            dt.AddProperty(typeof(string), "PropertyIWantToHide", etc..);
        }
        ... etc ...
        propertyGrid1.SelectedObject = dt.FromComponent(c);
    }
    public class MyBeautifulClass
    {
    }
