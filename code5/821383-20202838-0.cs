     string Query = "SELECT p.PID,  p.PName, (p.Weight * b.Foodcost) + p.VetBill + b.Housing AS TotalCost FROM pet p INNER JOIN breed b ON p.BreedID = b.BreedID";
            OleDbCommand myCommand = new OleDbCommand(myQuery, con);
       List<int> val = new List<int>();
        try
        {
            con.Open();
            OleDbDataReader reader = myCommand.ExecuteReader();
    
    
            while (reader.Read())
            {
              val.Add(reader.GetInt32(2));
    
    
            }
        }
    
        catch (Exception ex)
        {
            Console.Write("Error " + ex);
        }
    return val;
