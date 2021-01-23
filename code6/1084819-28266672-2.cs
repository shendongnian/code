       else if (firstArray.Length == secondArray.Length)
       {
          bool resolved = false;
          for (int i = 0; i < length; i++)
          {
              if (firstArray[i] > secondArray[i])
              {
                  Console.WriteLine("2 array is earlier.");
                  resolved = true;
                  break;
              }
              if (secondArray[i] > firstArray[i])
              {
                  Console.WriteLine("1 array is earlier."); 
                  resolved = true;
                  break;
              }
          }
          if (!resolved)
          {
              Console.WriteLine("Two arrays are equal.");
          }
       }
