     for (int counter = 0; counter < Array1.Length; counter++)
     {
         if (Array1[counter] == "your string here")
         {
             //Print same line on remaining arrays, eg:
             Console.WriteLine(Array2[counter]);
             Console.WriteLine(Array3[counter]);
             //Then you can break out of the loop
             break;
         }
     }
