    public class GameContainer {
      public GameContainer() {
         Date = new Date();
      }
      public static readonly DependencyProperty DateProperty = 
           DependencyProperty.Register("Date", typeof(Date), typeof(GameContainer));
      public Date Date {
         get { return (Date) GetValue(DateProperty);}
         set {
            SetValue(DateProperty, value);
         }
      }
    }
