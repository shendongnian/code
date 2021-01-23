ContentControlRightPanelStyle
    <Style x:Key="ContentControlRightPanelStyle" TargetType="{x:Type ContentControl}">
        <Setter Property="ContentTemplateSelector" Value="{StaticResource MyTemplateSelector}" />                
        
        <Setter Property="DataTemplateSelectors:DynamicTemplateSelector.Templates">
            <Setter.Value>
                <DataTemplateSelectors:TemplateCollection>
                    <DataTemplateSelectors:Template Value="DateCalculator" 
                                                    DataTemplate="{StaticResource DateCalcTemplate}" />
                    <DataTemplateSelectors:Template Value="Test" 
                                                    DataTemplate="{StaticResource TestTemplate}" />
                </DataTemplateSelectors:TemplateCollection>
            </Setter.Value>
        </Setter>
    </Style>    
DynamicTemplateSelector (taken and little reworked from CodeProject)
    public class DynamicTemplateSelector : DataTemplateSelector
    {
        #region Templates Dependency Property
        public static readonly DependencyProperty TemplatesProperty =
            DependencyProperty.RegisterAttached("Templates", typeof(TemplateCollection), typeof(DataTemplateSelector),
            new FrameworkPropertyMetadata(new TemplateCollection(), FrameworkPropertyMetadataOptions.Inherits));
        public static TemplateCollection GetTemplates(UIElement element)
        {
            return (TemplateCollection)element.GetValue(TemplatesProperty);
        }
        public static void SetTemplates(UIElement element, TemplateCollection collection)
        {
            element.SetValue(TemplatesProperty, collection);
        }
        #endregion
        #region SelectTemplate
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            string myStringItem = (string)item;
            if (!(container is UIElement))
            {
                return base.SelectTemplate(item, container);
            }
            
            TemplateCollection templates = GetTemplates(container as UIElement);
            if (templates == null || templates.Count == 0)
            {
                base.SelectTemplate(item, container);
            }
            foreach (var template in templates)
            {
                if (myStringItem.Equals(template.Value.ToString()))
                {
                    return template.DataTemplate;
                }
            }
            return base.SelectTemplate(item, container);
        }
        #endregion
    }
    #region TemplateCollection
    public class TemplateCollection : List<Template>
    {
    }
    #endregion
    #region Template Dependency Object
    public class Template : DependencyObject
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(Template));
        public static readonly DependencyProperty DataTemplateProperty =
           DependencyProperty.Register("DataTemplate", typeof(DataTemplate), typeof(Template));
        public string Value
        { get { return (string)GetValue(ValueProperty); } set { SetValue(ValueProperty, value); } }
        public DataTemplate DataTemplate
        { get { return (DataTemplate)GetValue(DataTemplateProperty); } set { SetValue(DataTemplateProperty, value); } }
    }
    
    #endregion
Conclusion for several ViewModels / one main View
