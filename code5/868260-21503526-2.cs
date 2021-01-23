    public interface ILastUpdatable
    {
       DateTime LastUpdated {get;set;}
    }
     
    public partial class LOG_Departments : ILastUpdatable
    {
    }
