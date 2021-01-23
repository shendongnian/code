      [ServiceContract]
        public interface IService
        {
       
     [WebGet(UriTemplate = "GetStates", ResponseFormat = WebMessageFormat.Json)]
            [OperationContract]
            List<ServiceData> GetStates();
      }
    
    And in Service.cs
    
            public List<ServiceData> GetStates()
            {
                using (var db = new local_Entities())
                {
                   
                    var statesList = db.States.ToList();
    
                    return statesList.Select(state => new ServiceData
                    {
                        Id = state.StateId, Value = state.StateName
                    }).OrderBy(s => s.Value).ToList();
    
                }
            }
    
    Note you have to just return the return type collection, at my end I have a List of ServiceData 
      public class ServiceData
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
