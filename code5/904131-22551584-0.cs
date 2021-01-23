    int index = 0; // Maybe the current row index
    var idString = GridView1.DataKeys[index].Value as string;
    int ID;
    if(idString != null && int.TryParse(idString, out ID))
    {
      // The value present in the grid is not valid integer value.
      throw new Exception("DataKey is not a valid integer."); 
    }
