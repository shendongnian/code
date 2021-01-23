    public class MyUserControlViewModel
        {
            public MyUserControlViewModel()
            {
                VehicleArr = new VehicleViewModel[6];
                for (int i = 0; i < 6;i++ )
                    VehicleArr[i] = new VehicleViewModel();
            }
            public VehicleViewModel[] VehicleArr { get; set; }
        }
