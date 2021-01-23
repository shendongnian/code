    private static Cached<List<Models.CarModel>> _carModels =
          new Cached<List<Models.CarModel>>(
              GetCarModels_P, "GetCarModels", TimeSpan.FromHours(1));
    
    public static List<Models.CarModel> GetCarModels()
    {
        return _carModels.GetValue(false);
    }
