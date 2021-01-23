    public class MyModel 
    {
        public string Id {get;set;}
        //public valuetype PropertyA {get;set;}  //other properties
    }
    
    public interface IMyModelRepository
    {
        List<MyModel> GetModels();
        MyModel GetModelById(string id);
        void AddMyModel(MyModel model);
        //other ways you want to get models etc
    }
    
    public class MyModelRepositorySql : IMyModelRepository
    {
        public List<MyModel> GetModels()
        {
            //SqlConnection etc etc
            while (SqlDataReader.Read())
            {
               results.Add(this.populateModel(dr));
            }
            return results;
        }
    
        protected MyModel populateModel(SqlDataReader dr)
        {
            //map fields to datareader
        }
    
        public MyModel GetModelById(string id)
        {
            //sql conn etc
            this.populateModel(dr);
        }
    }
