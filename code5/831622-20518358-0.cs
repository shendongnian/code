    private DataTemplate GetDataTemplate(string columnName)
    {
        string xaml = "<DataTemplate><ComboBox SelectedValue=\"{Binding Path=[" + columnName +
                      "].SelectedEnumeratedElementItem, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}\"" +
                      " ItemsSource=\"{Binding Path=[" + columnName +
                      "].Items}\" DisplayMemberPath=\"Name\"/></DataTemplate>";
    
        var sr = new MemoryStream(Encoding.ASCII.GetBytes(xaml));
        var pc = new ParserContext();
        pc.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
        pc.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
        var datatemplate = (DataTemplate)XamlReader.Load(sr, pc);
    
        return datatemplate;
    }
