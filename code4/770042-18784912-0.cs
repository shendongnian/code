     private void Button_Click(object sender, EventArgs e)
     {
          var newItem = // get new number
     
          if (list.Any()) // or list.Count > 0
          {
              var previousItem = list.Last(); // or list[list.Count - 1]
              // compare newItem with previous
          }
     
          list.Add(newItem);
     };
