    public static class Program
    {
        static void main(string[] args)
        {
            ParkManager parkManager = new ParkManager();
            parkManager.CreateParks();
            foreach (Park park in parkManager.Parks)
            {
                // do something with park
                
            } 
        }
    }
    
    public class ParkManager
    {
        // Setter is private to prevent other classes from replacing the list
        // This doesn't prevent other classes from adding or removing,
        // replacing or editing items in the list
        public List<Park> Parks {get; private set;}
       
        // Constructor - you could populate the list from here if appropriate
        public void ParkManager()
        {
            Parks = new List<Park>();
        }
    
        public void CreateParks()
        {
          // Populate the list of parks here
        }
    }
