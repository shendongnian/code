         public const string AttendanceCollectionPropertyName = "AttendanceCollection";
         private ObservableCollection<AttendanceModel> _attendanceCollection = null;
         public ObservableCollection<AttendanceModel> AttendanceCollection
          {
           get
           {
            if (_attendanceCollection == null)
            {
                _attendanceCollection = new ObservableCollection<AttendanceModel>();
            }
            return _attendanceCollection;
          }
           set
          {
            Set(AttendanceCollectionPropertyName, ref _attendanceCollection, value);
            _attendanceCollection.CollectionChanged+= handler
          }
        } 
         private void handler(object sender, NotifyCollectionChangedEventArgs e)
         {
          foreach (AttendanceModel model in AttendanceCollection)
                model.PropertyChanged += somethingChanged;
          }
          // Very ineffective to subscribe to all elements every time a list changes but I leave optimization to you.
         private somethingChanged (object obj, PropertyChangedEventArgs args)
         {
           if ( args.PropertyName == "CheckIn" ) // for example
            { 
                  AttendanceModel ModelToRecalculate = obj as AttendanceModel;
                  // You can do anything you want on that model.
            }
         }
