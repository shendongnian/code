    List<int> liNumeric = new List<int>();  
     foreach (string st in liRoom)  
     { 
       // int.Parse will fail if you don't have any digit in the input 
       if(st.Any(char.IsDigit))
       {
           liNumeric.Add(int.Parse(new string(st.Where(char.IsDigit).ToArray()))); 
       }
      
     }  
     if (liNumeric.Any()) //Max will fail if you don't have items in the liNumeric
     {
         int MaxValue = liNumeric.Max();
     }
