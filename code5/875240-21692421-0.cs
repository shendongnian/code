    List<int> liNumeric = new List<int>();  
     foreach (string st in liRoom)  
     { 
       if(st.Any(char.IsDigit))
       {
           liNumeric.Add(int.Parse(new string(st.Where(char.IsDigit).ToArray()))); 
       }
      
     }  
     int MaxValue = liNumeric.Max();
