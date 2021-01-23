     int result
     if(!Int32.TryParse(txtempty.Text, out result)
     {
          MessageBox.Show("Not a valid integer number");
          return;
     }
     id = result + 1;
     ....
