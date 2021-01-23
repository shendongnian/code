        public DataTemplate CreateDataTemplate(Type type, int aNumber)
        {
            StringReader stringReader = new StringReader(
            @"<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""> 
            <" + type.Name + @" Text=""{Binding WrapperCollection[" + aNumber.ToString() + @"].Value}""/> 
        </DataTemplate>");
            XmlReader xmlReader = XmlReader.Create(stringReader);
            return XamlReader.Load(xmlReader) as DataTemplate;
        }
    {
        ...
        TextBlock textBlock = new TextBlock();
        var lMyCellTemplate = CreateDataTemplate(textBlock.GetType(), Counter);
    }
