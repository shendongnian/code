    List<data> DataList = new List<data>();
    int itemsCount = 20;
    for (int i = 0; i < itemsCount; i++)
    {
         data NewData = new data();
         NewData.Present= i % 2 == 0;
         NewData.RollNo = i;
         DataList.Add(NewData);
    }
    TxtCompanyName.DataContext = e.Result;
