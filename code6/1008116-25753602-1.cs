    if (bar.Value == 100)
         {
           int value;
            if(!int.TryParse(f1.label1.Text,out value))
             {
               f1.label1.Text = "1";
             }
            else
            {
                 f1.label1.Text = ""+(value+1); 
            }
         }
