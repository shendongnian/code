    public class PersonQueryCreator : DependencyObject
    {
      #region Static Data Members
      public static DependencyProperty ShortNameToSearchProperty = DependencyProperty.Register("ShortNameToSearch", typeof(string), typeof(PersonQueryCreator), new PropertyMetadata(UpdateQueryObject));
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
        ...
      }
      #endregion
    }
