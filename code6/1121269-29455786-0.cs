    List<string> input = new List<string> { "1", "2", "three", "4", "five", "eight", "9" };
    
   
    List<int> output1 = new List<int>{};  // keep the list here integer values
    List<string> output2 = new List<string> { }; // keep the list here non numericic values
    foreach(var temp in input)
    {
       bool k=int.TryParse(numberString , out temp );
       if(k==true)
       {
         output1.add(temp)
       }
       else
       {
         output2.add(temp)
       }
    }
