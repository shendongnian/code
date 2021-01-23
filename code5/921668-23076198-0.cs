    public class templateSelector : DataTemplateSelector
    {
        private DataTemplate _Template1;
        public DataTemplate Template1
        {
            get { return _Template1; }
            set { _Template1 = value; }
        }
        private DataTemplate _Template2;
        public DataTemplate Template2
        {
            get { return _Template2; }
            set { _Template2 = value; }
        }
       
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            YourClass obj = (YourClass)item;
            if (obj.Type == "SomeType")
            {
                return Template1;
            }
            else
            {
                return Template2;
            }
        }
    }
    <ListView.ItemTemplateSelector>
        <local:FieldRangeTemplateSelector 
            Template1="{StaticResource YouyTemplate1}"
            Template2="{StaticResource YoutTemplate2}" />
    </ListView.ItemTemplateSelector>
