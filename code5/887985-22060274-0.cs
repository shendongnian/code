    public class Member
    {
    string name;
    bool isMarried;
    string spouseName;
    
    public string Name
    {
    get { return name; }
    set { name = value; }
    }
    
    [System.ComponentModel.RefreshProperties(RefreshProperties.All)]
    public bool IsMarried
    {
    get { return isMarried; }
    set
    {
    isMarried = value;
    bool newValue = !value;
    PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())["SpouseName"];
    ReadOnlyAttribute attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
    FieldInfo isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
    isReadOnly.SetValue(attrib, newValue);
    }
    }
    
    [ReadOnly(true)]
    public string SpouseName
    {
    get { return spouseName; }
    set
    {
    spouseName = value;
    }
    }
    }
