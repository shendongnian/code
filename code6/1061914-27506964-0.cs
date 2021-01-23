    public async Task ShowListsAsync()
    {
      LoadingOverlay loadingOverlay = new LoadingOverlay ();
      loadingOverlay.Show();
      try
      {
        List<Car> carList = await Task.Run(() => manager.GetCarList());
        List<string> manufacturers = extractIDs(carList);
        List<Manufacturer> manufacturerList = await Task.Run(() => manager.GetManufacturerList(manufacturers));
        Table.Show(carList, manufacturerList);
      }
      catch
      {
        alert.Show("Something went wrong");
      }
      finally
      {
        loadingOverlay.Hide();
      }
    }
