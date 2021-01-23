    public class myModel 
    {
     public string Id {get;set;}
     public valuetype PropertyA {get;set;}  //other properties
    }
    
    public interface IMyModelRepository
    {
     public List<myModel> GetModels();
     public myModel GetModelById(string id);
    //other ways you want to get models etc
    }
    
    public class MyModelRepositorySql : IModelRepository
    {
     public List<myModel> GetModels()
    {
     //SqlConnection etc etc
    }
     protected myModel populateModel(SqlDataReader dr)
    {
     //map fields to datareader
    }
    
     public myModel GetModelById(string id)
    {
    //sql conn etc
    }
