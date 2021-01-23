    private void intSchedular()
    {
        // CREATE 
        using(OleDbConnection con = new OleDbConnection(... con string here....))
        using(OleDbCommand createCommand = new OleDbCommand("select * from CarScheduling", con))
        {
             // OPEN
             con.Open();
             using(OleDbDataAdapter adapter = new OleDbDataAdapter(createCommand))
             {
                // USE
                ....
                adapter.Fill(dataSet.CarScheduling);
                ....
             }
        } // CLOSE + DISPOSE
    }
