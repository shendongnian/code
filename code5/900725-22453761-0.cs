    public class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MeTemplate { get; set; }
        public DataTemplate YouTemplate { get; set; }
        public override DataTemplate SelectTemplate(
            object item, DependencyObject container)
        {
            var message = item as Message;
            return message.Side == MessageSide.Me ? MeTemplate : YouTemplate;
        }
    }
