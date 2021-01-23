      public class MessageConverter: IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
          var message = (Message) value;
          if(message.Italic)
          {
             var it = new Italic();
             it.Inlines.Add(new Run{Text = message.MessageLine});
             it.Inlines.Add(new LineBreak());
             return it;
          }
          else if(...)
          { 
             ...
          }
          return ...;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
          throw new NotImplementedException();
        }
      }
