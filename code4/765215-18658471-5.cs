      private void addButton0_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           string buttonName = ((Button)sender).Name;
           string buttonNumber = buttonName.SubString(0,buttonName.Length -1 );
        
           switch(buttonNumber)
           {
             case "0":
             // do work for 0
              break;
              case "1":
              // do work for 1
             break;
            } 
        }
