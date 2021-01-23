    public class Test
    {
        public int ID;
        public int? WorkingID;
    }
    class Program
    {
    static void Main(string[] args)
    {
        var A = new List<Test>() 
        { 
            new Test { ID = 5, WorkingID = null }, 
            new Test { ID = 9, WorkingID = null }, 
            new Test { ID = 16, WorkingID = null }, 
            new Test { ID = 18, WorkingID = null } 
        };
        var B = new List<Test>() 
        { 
            new Test { ID = 5, WorkingID = 1 }, 
            new Test { ID = 9, WorkingID = 2 }, 
            new Test { ID = 16, WorkingID = 3 } 
        };
        A.ForEach(c => c.WorkingID = B.Where(m => m.ID == c.ID).Select(s => s.WorkingID).FirstOrDefault());
    }
    }
