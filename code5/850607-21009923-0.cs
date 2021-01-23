    public static DataTemplate Create(Type type)
    {
        var templateString = 
            "<DataTemplate " +
                "xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" " +                                   
                "xmlns:" + type.Name.ToLowerInvariant() +
                     "=\"clr-namespace:" + type.Namespace +
                     ";assembly=" + type.Assembly.GetName().Name + "\">" +
            "<" + type.Name.ToLowerInvariant() + ":" + type.Name + "/>" +
            "</DataTemplate>";            
        return XamlReader.Load(templateString) as DataTemplate;
    }
