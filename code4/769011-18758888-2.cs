    namespace StackOverFlow
    {
              public class TemplateSelector : DataTemplateSelector
              {
                public DataTemplate IncomingMessageTemplate { get; set; }
                public DataTemplate OutgoingMessageCaptureTemplate { get; set; }
                public DataTemplate EmptyTemplate { get; set; }
            
                public override DataTemplate SelectTemplate(object item, DependencyObject container)
                {
                  var x = item as Message;
                  if (x != null)
                  {
                    return (x.IsIncoming) ? IncomingMessageTemplate : OutgoingMessageCaptureTemplate;
                  }
            
                  return EmptyTemplate;
                }
              }
    }
