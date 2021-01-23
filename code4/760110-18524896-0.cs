    public partial class Grid
    {
       public void AddItem(GridItem item)
       {
          item.InformAddedToGrid();
       }
    }        
     
    public class GridItem
    {
       public void InformAddedToGrid()
       {                
          if (new StackTrace().GetFrame(1).GetMethod().DeclaringType != 
                       typeof(Grid)) throw new Exception("Tantrum!");
          Console.WriteLine("Grid called in...");
    
       }
    }
