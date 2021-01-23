    public void ExportKml()
    {
        string query = string.Empty;
            switch (txtTable.SelectedIndex)
            {
                case 0:
                    query = "Select * from dbo.HyacinthWaterBodyZones";
                    break;
                case 1:
                    query="Select * from lchcd.privateWatersFinal where waterbodypolygon is not null";
                    break;
                case 2:
                    query = "Select * from lchcd.publicWatersFinal where waterbodypolygon is not null";
                    break;
                default:
                    query = "";
                    break;
            }
 
            // Add a check for empty string before trying the query.
            if(!string.IsNullOrWhiteSpace(query))
            {
                cs.Open();
                SqlCommand cmd = new SqlCommand(query, cs);
                SqlDataReader polygon = cmd.ExecuteReader();
            }
    }
