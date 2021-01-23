    public class BindingMiddle : DependencyObject
    {
      #region Static Data Members
      public static DependencyProperty MiddleValueProperty = DependencyProperty.Register("MiddleValue", typeof(object), typeof(BindingMiddle));
      #endregion
      #region Public Properties
      public object MiddleValue
      {
        get { return GetValue(MiddleValueProperty); }
        set { SetValue(MiddleValueProperty, value); }
      }
      #endregion
    }
    public class PersonQueryCreator : DependencyObject
    {
      #region Static Data Members
      public static DependencyProperty ShortNameToSearchProperty = DependencyProperty.Register("ShortNameToSearch", typeof(string), typeof(PersonQueryCreator), new PropertyMetadata(ShortNameChanged));
      private static DependencyPropertyKey QueryPropertyKey = DependencyProperty.RegisterReadOnly("Query", typeof(string), typeof(PersonQueryCreator), new PropertyMetadata());
      public static DependencyProperty QueryProperty = QueryPropertyKey.DependencyProperty;
      #endregion
      #region Public Properties
      public string ShortNameToSearch
      {
        get { return (string)GetValue(ShortNameToSearchProperty); }
        set { SetValue(ShortNameToSearchProperty, value); }
      }
      public object Query
      {
        get { return (string)GetValue(QueryProperty); }
      }
      #endregion
      #region Public Methods
      public static IPerson SearchForPerson(object query)
      {
        string shortNameToSearch = query as string;
        return new Prayer(shortNameToSearch, shortNameToSearch);
      }
      #endregion
      #region Private Methods
      private static void ShortNameChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
      {
        ((PersonQueryCreator)o).SetValue(PersonQueryCreator.QueryPropertyKey, e.NewValue);
      }
      #endregion
    }
