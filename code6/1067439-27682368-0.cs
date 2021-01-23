            Console.WriteLine("Enter 1, 2, 3, OR 4");
            uI = int.Parse(Console.ReadLine());
            while(uI > 0) //exit loop if 0 is entered
            {
               switch(uI)
               {
                  case 1: Console.WriteLine("msg"); break;
                  case 2: Console.WriteLine("msgg"); break;
                  case 3: Console.WriteLine("msggg"); break;
                  case 4: Console.WriteLine("msgggg"); break;
                  default: break; //do not write to console just loop again
      
               }
               Console.WriteLine("Enter 1, 2, 3, OR 4");
               uI = int.Parse(Console.ReadLine());
            }           
      
