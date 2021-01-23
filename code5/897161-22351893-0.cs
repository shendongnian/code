    public abstract class DataTemplateSelector : ContentControl
    {
        public virtual DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return null;
        }
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            ContentTemplate = SelectTemplate(newContent, this);
        }
    }
    public class CustomTemplateSelector : DataTemplateSelector
    {
        public DataTemplate First
        {
            get;
            set;
        }
        public DataTemplate Second
        {
            get;
            set;
        }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Data data = item as Data;
            if (data != null)
            {
                if (data.ShowLineThree)
                {
                    return this.Second;
                }
                else
                {
                    return this.First;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
    public class Data
    {
        public string LineOne
        {
            get;
            set;
        }
        public string LineTwo
        {
            get;
            set;
        }
        public string LineThree
        {
            get;
            set;
        }
        public bool ShowLineThree
        {
            get;
            set;
        }
    }
