    public class Program
        {
            public static void Main(string[] args)
            {
                var col = new ColTest();
                col.MakeList();
             }        
    }
    
    public class ColTest
        {
            public ArrayList MakeList()
            {
                var capacity = 3;
                ArrayList myList = new ArrayList(capacity);
                int size = 2;
                for (int run = 0; run < capacity; run++)
                {
                    byte[] _byteArray = new byte[size];
    
                    if (run == 0)
                    {
                        _byteArray[0] = 0;
                        _byteArray[1] = 0;
                    }
                    else if (run == 1)
                    {
                        _byteArray[0] = 0;
                        _byteArray[1] = 1;
                    }
                    else if (run == 2)
                    {
                        _byteArray[0] = 1;
                        _byteArray[1] = 1;
                    }
    
                    myList.Add(_byteArray);
                }
    
                return myList;
            }
        }
