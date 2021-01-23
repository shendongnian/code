            string str ="¿Cómo puede hacerse esto?";
            string newMStr = string.Empty; 
            foreach (var ch in str)
            {
                int chCode = Convert.ToInt16(ch); 
                if (chCode>127)
                {
                    newMStr += string.Format("&#{0};", chCode);
                }
                else
                {
                    newMStr += ch;    
                }
                
            }
            
            
            //Print  NewMstr
   
