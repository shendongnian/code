     public class PuzzleName
        {
         public String Name { get; set; }
         public string puzzle{ get; set; }
        
            } 
    
    public class Puzzle
     {
    
     public String CategoryName { get; set; }
     public List<PuzzleName> Children { get; set; }
    
            public Puzzle(string Categoryname)
            {
                Children = new List<PuzzleName>();
    	    CategoryName= Categoryname;
            }
    //read the xml file and create an object for the puzzle and load the puzzle name (#1) as its childern
    }
