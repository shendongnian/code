    public void FillGridview()
    {
        reader = Select * from film;
    
        while (reader.Read())
        {
            reader2 = Select time from filmtime where theatername = reader["theatername"];
            //add the filmname and the theatrename to the gridview-cells here
            while (reader2.Read())
            {
                //add the times to the gridview-cell here (You can start a new line if you want a break with Environment.NewLine()
            }
    
        }
    }
