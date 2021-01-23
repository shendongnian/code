     private static int ReadValidAge(int guestNumber)
     {
          int result;
          for(int i = 3; i > 0;)
          {
              Console.Write("Enter Age of guest {0}: ", guestNumber);
              if(int.TryParse(Console.ReadLine(),out result) && result > 0)
              {
                  return result;
              }
              else
              {
                   Console.WriteLine("Invalid Age entered ... {0} Tries left!", --i); 
              }
          }
          return -1;
     }
