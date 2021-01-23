    interface IHomesRepository {
      List<Home> GetAllHomes();
      Home GetHomeById(int id);
      void AddHome(Home home);
      void UpdateHome(int id, Home home);
      void DeleteHome(Home home);
    }
    
    interface IUnitOfWork : IDisposable{
       IHomesRepository repository {get;}
       // more repositories, if required
       void Commit();
    }
