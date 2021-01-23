    using System.Windows;
    using System.Windows.Controls;
    
    namespace Common.TemplateSelector
    {
        public class LanguageTemplateSelector : DataTemplateSelector
        {
            public DataTemplate TemplateEnglish { get; set; }
            public DataTemplate TemplateGerman { get; set; }
    
            public const string LanguageIdentifier = "de";
    
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                return Configuration.Configuration.Language == LanguageIdentifier ? this.TemplateGerman : this.TemplateEnglish;
            }
        }
    }
