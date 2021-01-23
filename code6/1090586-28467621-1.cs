    using (SQLiteDataReader rdr = cmd.ExecuteReader())
    {
      if (rdr.Read()){
                        dsdValsForUPCCode.Add(Convert.ToString(rdr["Line_id"]));       // Line_id, int32
                        dsdValsForUPCCode.Add(Convert.ToString(rdr["Description"]));   // Description
                        dsdValsForUPCCode.Add(Convert.ToString(rdr["Department"]));    // Department
                        dsdValsForUPCCode.Add(Convert.ToString(rdr["Upc_pack_size"])); // Upc_pack_size (int32)
                        dsdValsForUPCCode.Add(Convert.ToString(rdr["Pack_size"]));     // Pack_size (int32)
                        dsdValsForUPCCode.Add(Convert.ToString(rdr["Unit_qty"]));      // Unit_qty (single)
                        }
             }
