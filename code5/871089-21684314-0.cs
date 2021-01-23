     public class Parent
     {
          private INotifyValue<bool> _allTwoDegrees;
          public Parent()
          {
              _allTwoDegrees = Observable.Expression(() => Children.WithUpdates().All(child => child.HasTwoDegrees));
              _allTwoDegrees.ValueChanged += (o,e) => OnPropertyChanged("AllTwoDegrees");
          }
          public bool AllTwoDegrees
          {
              get
              {
                  return _allTwoDegrees.Value;
              }
          }
          ...
     }
