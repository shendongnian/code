    public class DirectoryService : IDirectoryService
    {
         public DirectoryService(IProvinceRepository repo, IDispatchMessage bus) 
         { 
           //assign fields
         }
          /* other stuff */
          //maybe province is an input model which is used by the service to create a business Province?
          public void AddProvince(Province province)
         {
           
            _repo.Save(province);
            _bus.Publish( new ProvinceCreated(province));
         }
    }
      public class StatsUpdater:ISubscribeTo<ProvinceCreated> /* and other stat trigger events */
       {
           public void Handle(ProvinceCreated evnt)
           {
                  //update stats here
           }  
       }
