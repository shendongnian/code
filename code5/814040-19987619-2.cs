    try
    {
        string cmdText = "INSERT INTO HafizwalaTable(DistrictName, " + 
            "TownName, FarmerName, Area, VarietyOfCrop, SowingDate, VisitDate, PestPopulation1, " + 
            "PestPopulation2, PestPopulation3, PestPopulation4, PestPopulation5, " + 
            "PestPopulation6, PestPopulation7, PestPopulation8, PestPopulation9, " + 
            "PestPopulation10, PestPopulation11, PestPopulation12, PesticideUsed, " + 
            "PesticideSprayDate, PesticideDosage, CLCV, PlantHeight) " + 
            "VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14, "
            "@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24)";
        using(SqlConnection con = new SqlConnection(GetConnectionString())
        using(SqlCommand comm = new SqlCommand(cmdText, con);
        {
            comm.Parameters.AddWithValue("@p1",FileReaderDataArray[RowNo, 0]);
            comm.Parameters.AddWithValue("@p2",FileReaderDataArray[RowNo, 1]);
            comm.Parameters.AddWithValue("@p3",FileReaderDataArray[RowNo, 2]);
    
            ..... and so on, add the other parameters. all 24 if I have counted them well
    
            comm.ExecuteNonQuery();
         }
     }
     catch(Exception ex)
     {
         MessageBox.Show(ex.Message);
     }
    
