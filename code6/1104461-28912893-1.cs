    Public string[] DeleteClasses(int indexId)
    {
        //indexId will be depends upon user selection on demand for delete     
        // operation.
        cArray = cArray .Where((source, index) => index != indexId).ToArray();
    }
    public void displayClasses()
    {
       try{
            int indexId=classList.SelectedItemIndex;//
            string[] cArray = DeleteClasses(int indexId);
            classList.Items.Clear();
            classList.Items = cArray.ToList(); //here cArray is updated data array
           }
          catch (Exception e)
          {
           MessageBox.Show(e.Message, "Displaying Error!");
          }
    }
