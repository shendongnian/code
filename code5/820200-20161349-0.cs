     class Program
      {
            static void Main(string[] args)
          {
            
              Array results = new[] { new { RoomCount = "2", Cover = "5", Space = "5", Floor = "5",    FloorCount = "5", NameHouse = "5", Price = "5", NameStreet = "5" } };            
            //with this line not cpmmented does not compile  
              Array.Resize(ref results, results.Length + 5);            
 
            String[] myArr = {"The", "quick", "brown", "fox", "jumps", 
            "over", "the", "lazy", "dog"};
            Array.Resize(ref myArr, myArr.Length + 5);
            
            MyTest[] resultsMyTest = new MyTest[] {new MyTest{RoomCount=3,Cover="Red"}};
            //here  it will work  as the compiler know  how to infer it 
            Array.Resize(ref resultsMyTest, results.Length + 5);            
           
        }
        public class  MyTest
        {
            public int RoomCount
            {
                get;
                set; 
            }
            public string Cover
            {
                get;
                set;  
            }
        }
    }
