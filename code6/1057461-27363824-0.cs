    public class ImgStringTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ImageTemplate { get; set; }
        public DataTemplate StringTemplate { get; set; }
    
        public override DataTemplate SelectTemplate(object item, 
            DependencyObject container)
        {
            String path = (string)item;
            String ext = System.IO.Path.GetExtension(path);
            if (System.IO.File.Exists(path) && ext == ".jpg")
                return ImageTemplate;
            return StringTemplate;
        }
    }
