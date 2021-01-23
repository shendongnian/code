      for (int i = 0; i < 5; ++i){
      //number=i+1 and its stat will be at Count[i]
          Console.Write("{0,2} Adet {1,2} >>>>", Count[i], i+1);
          for (int j = 0; j < Count[i]; j++) {
                Console.Write("*");
             }
          Console.WriteLine();
       }
