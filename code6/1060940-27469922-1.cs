     private bool IsFound(string input)
        {
           
            string[] a1_values = input.Split(',');
            
            foreach (string item in a1_values)
            {
                if (item == "1")
                {
                   
                   return true;
                }
                else
                {
                    
                    return false;
              
            }
           
        }
