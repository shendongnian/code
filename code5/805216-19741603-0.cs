    public class MobileServiceClient : IMobileServiceClient
    {
     private IRepository _repository;
     
     // repository is resolved and injected by PhoneContainer 
     public MobileServiceClient (IRepository repository)
     {
      _repository = repository;
     }
    }
