    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TextComponent : INotifyPropertyChanged  {
      public event PropertyChangedEventHandler PropertyChanged;
      protected void OnChanged(string propertyName) {
        if (PropertyChanged != null) {
          PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
      }
      private string text = string.Empty;
      [NotifyParentProperty(true)]
      public string Text {
        get { return text; }
        set {
          text = value;
          OnChanged("Text");
        }
      }
    }
