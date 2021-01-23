    TableCount = 0;
    foreach (var schema in PermisList)
    {
       TableCount += schema.Count;
    }
    If (PropertyChanged != null)
         PropertyChanged(this, new PropertyChangedEventArgs("TableCount"));
