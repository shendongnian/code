                public static T SetupController<T>() where T : ApiController, new()
                {
                    //LocalDB database to the tests directory.
                    AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
                    var request = new HttpRequestMessage();
                    var config = WebApiConfig.SetupRegister(new HttpConfiguration());
                    var controller = new T()
                    {
                        Request = request,
                        Configuration = config
                    };
                    return controller;
                }
