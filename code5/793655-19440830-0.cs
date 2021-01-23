      int noneCount = 0;
      while (!inFile.EndOfStream)
      {
          inValue = inFile.ReadLine();
          if (inValue.Contains("'NONE"))
          {
               noneCount++;
          }
      }
      Console.WriteLine(noneCount);
           
      Console.ReadKey();
