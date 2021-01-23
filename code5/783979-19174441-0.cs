    class MyViewModel : INotifyPropertyChanged
    {
      private IModelRepository _repository;
      public MyViewModel(IModelRepository repository)
      {
        _repository = repository;
        Models = repository.GetAllModels();
      }
      public IEnumerable<DataModel> Models { get; set; }
    }
    public interface IModelRepository
    {
      IEnumerable<DataModel> GetAllModels();
    }
    public class MyRepository : IModelRepository
    {
      public IEnumerable<DataModel> GetAllModels()
      {
        // obviously nowhere near final code!!!
        return new List<DataModel> { 
                          new DataModel { 
                                 FirstName = MyDS.Tables[0].Rows[0][1].ToString() 
                          } 
                   };
      }
    }
