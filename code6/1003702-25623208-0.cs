    public class HallListing : BaseViewModel
    {
         private List<hall> halls;
         public void LoadData() 
         {
              this.halls = base.db.halls.Take(30).ToList();
         }
    }
    
    abstract class BaseViewModel 
    {
         protected DataContext db { get; private set; }
         public BaseViewModel() 
         {
              this.db = new DataContext();
         }
    }
