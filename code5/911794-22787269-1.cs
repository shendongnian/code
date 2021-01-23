      public OberservableCollection<Meter> MyMeter {get;set;}
      public void GetMetersOnCurrentCellID()
      {
          var l = meters.Where(x => x.Gsmdata.Last()
                 .CellID == CurrentCellID.Key)
                 .ToList();
          MyMeter.Clear();
          foreach(var item in l)
             MyMeter.Add(item);
      }
      <DataGrid Name="2ndGrid" ItemsSource="{Binding Path=MyMeter}" />
