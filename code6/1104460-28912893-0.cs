    try{
        classList.Items.Clear();
        classList.Items = cArray.ToList(); //here cArray is updated data array
       }
      catch (Exception e)
      {
       MessageBox.Show(e.Message, "Displaying Error!");
      }
