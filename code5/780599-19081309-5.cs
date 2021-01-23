    private void intSchedular()
    {
        // CREATE 
        using(OleDbConnection con = new OleDbConnection(... con string here....))
        using(OleDbCommand createCommand = new OleDbCommand("select * from CarScheduling", con))
        {
             // OPEN
             con.Open();
             // NO USING HERE BECAUSE WE WANT THE ADAPTER OUTSIDE OF THIS METHOD
             adapter = new OleDbDataAdapter(createCommand);
             // USE
             ....
             adapter.Fill(dataSet.CarScheduling);
             ....
        } // CLOSE + DISPOSE
    }
