     // Here I declare your initial list.
     List<List<double>> list = new List<List<double>>()
     {
         new List<double>(){3,5,1},
         new List<double>(){5,1,8},
         new List<double>(){3,3,3},
         new List<double>(){2,0,4},
     };
     // That would be the list, which will hold the maxs.
     List<double> result = new List<double>();
     
     // Find the maximum for the i-st element of all the lists in the list and add it 
     // to the result.
     for (int i = 0; i < list[0].Count-1; i++)
     {
         result.Add(list.Select(x => x[i]).Max());
     }
