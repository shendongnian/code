    public class DBTable
    {
        public int Id {get; set;}
        public string Param1 {get; set;}
        // and others
    }
    public class ViewModelClass
    {
        public string CustomParam1 {get; set;}
        // and so on
    }
    //in web-api controller 
    public ViewModelClass GetData()
    {
        return new BLL.Data().GetData();
    }
    // in BLL namespace Data class
    public class Data()
    {
        //DAL - data access layer - implement it as you would like. 
        var ViewModelClass result = new DAL.DataDAO().GetData()
            .ConvertAll(x=> new ViewModelClass() { 
                // do all your transformation here
                CustomParam1 = x.Param1,
                // and other
            });    
    }
