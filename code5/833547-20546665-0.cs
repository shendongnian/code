    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Objects.SqlClient;
    
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                List<int> listArray = new List<int>();
    
                listArray.Add(0);
                listArray.Add(1);
                listArray.Add(2);
                listArray.Add(3);
                listArray.Add(4);
                listArray.Add(5);
                listArray.Add(6);
                listArray.Add(7);
    
                Random ra = new Random();
    
                List<int> staticArray = new List<int>();
    
                 //while there is an element in the list
                 while (listArray.Any())
                 {
                 int chosen = ra.Next(0, 8);
                 int loopIndex = 0;
                 bool ok = false;
    
        if(listArray.Contains(chosen))
        {
            ok = true;
        }
        
        else 
        {
            ok = false;
            continue;
        }
    
         var cardIndexes = from value in listArray
                           where value == chosen
                           select value;
    
    
        foreach (int item in cardIndexes.ToArray())
        {
            if (item == chosen && ok == true) 
            {
                staticArray.Add(chosen);
              //  staticArray[loopIndex].pathIndex = chosen;
                listArray.Remove(chosen);
                loopIndex++;
                ok = false;
                break;
            }
        }
    
        if (!cardIndexes.Any()) break;
                    }
            }
                
            
    	}
            
    }
    
    
    
    
    
    
      
