    interface IMyData 
    {
          string GetLastName();
    }
    
    class MyDataFromOldWebService
    {
        MyApi.MyApiV1 service;
        MyDataFromOldWebService(MyApi.MyApiV1 service)
        {
          this.service = service;
        }
        public string GetLastName()...
    }
    Dictionary<string, IMyData> services = new Dictionary<string, IMyData>()
      {
          { "Old Service", new MyDataFromOldWebService(new MyApi.MyApiV1(url))}
      };
