    private void GenerateCommands() {
        masterDataAdapter.InsertCommand = new SqlCommand();
        masterDataAdapter.InsertCommand.CommandText = "INSERT INTO [Project Customer UBF]([Project Id], [Customer Id]," +
            "[Host Support], Warehoused,[List Price per Case]) "  
        + " VALUES (@ProjID, @CustID, 1, @Ware, 4); "
        + " SELECT [Project Customer UBF Id],[Project Id], [Customer Id]," +
            "[Host Support], Warehoused,[List Price per Case]"
        + " FROM [Project Customer UBF] WHERE ([Project Customer UBF Id]= SCOPE_IDENTITY())";
        masterDataAdapter.InsertCommand.Connection = conn;
        masterDataAdapter.InsertCommand.Parameters.Add("@ProjID", SqlDbType.Int,4,"Project Id");
        masterDataAdapter.InsertCommand.Parameters.Add("@CustID", SqlDbType.Int,4,"Customer Id");
        masterDataAdapter.InsertCommand.Parameters.Add("@Host", SqlDbType.Bit,1,"Host Support");
        masterDataAdapter.InsertCommand.Parameters.Add("@Ware", SqlDbType.Bit,1,"Warehoused");
        masterDataAdapter.InsertCommand.Parameters.Add("@List", SqlDbType.Float,8,"List Price per Case");
   
        masterDataAdapter.UpdateCommand = new SqlCommand();
        masterDataAdapter.UpdateCommand.CommandText = "UPDATE [Project Customer UBF] SET [Project Id] = @ProjID, "  
        + " [Customer Id] = @CustID, [Host Support] = @Host, Warehoused = @Ware, [List Price per Case] = @List " 
            + "WHERE ([Project Customer UBF Id] = @PCID); "; 
        masterDataAdapter.UpdateCommand.Connection = conn;
        masterDataAdapter.UpdateCommand.Parameters.Add("@ProjID", SqlDbType.Int,4,"Project Id");
        masterDataAdapter.UpdateCommand.Parameters.Add("@CustID", SqlDbType.Int,4,"Customer Id");
        masterDataAdapter.UpdateCommand.Parameters.Add("@Host", SqlDbType.Bit,1,"Host Support");
        masterDataAdapter.UpdateCommand.Parameters.Add("@Ware", SqlDbType.Bit,1,"Warehoused");
        masterDataAdapter.UpdateCommand.Parameters.Add("@List", SqlDbType.Float,8,"List Price per Case");
        masterDataAdapter.UpdateCommand.Parameters.Add("@PCID", SqlDbType.Int,4,"Project Customer UBF Id");
        masterDataAdapter.DeleteCommand = new SqlCommand();
        masterDataAdapter.DeleteCommand.CommandText = "DELETE FROM [Project Customer UBF] "
            + " WHERE ([Project Customer UBF Id] = @PCID);";
        masterDataAdapter.DeleteCommand.Connection = conn;
        masterDataAdapter.DeleteCommand.Parameters.Add("@PCID", SqlDbType.Int,4,"Project Customer UBF Id"); 
      
        detailsDataAdapter.InsertCommand = new SqlCommand();
        detailsDataAdapter.InsertCommand.CommandText = "INSERT INTO [Project Customer Discount]([Project Customer UBF Id], "
    + " [Discount Type], [Discount Amt], [Discount UOM]) " 
            + " VALUES (@PCID, @Type, @Amt, @UOM); " 
            + " SELECT [Discount Id],[Project Customer UBF Id], "
    + " [Discount Type], [Discount Amt], [Discount UOM] " 
            + " FROM [Project Customer Discount] WHERE ([Discount Id] = SCOPE_IDENTITY())";
        detailsDataAdapter.InsertCommand.Connection = conn;
        detailsDataAdapter.InsertCommand.Parameters.Add("@PCID", System.Data.SqlDbType.Int,4, "Project Customer UBF Id");
        detailsDataAdapter.InsertCommand.Parameters.Add("@Type", SqlDbType.Int,4,"Discount Type");
        detailsDataAdapter.InsertCommand.Parameters.Add("@Amt", SqlDbType.Float,8,"Discount Amt");
        detailsDataAdapter.InsertCommand.Parameters.Add("@UOM", SqlDbType.NVarChar,2,"Discount UOM");
        detailsDataAdapter.UpdateCommand = new SqlCommand();
        detailsDataAdapter.UpdateCommand.CommandText = "UPDATE [Project Customer Discount] SET [Project Customer UBF Id] = @PCID, "
        + " [Discount Type] = @Type, [Discount Amt] = @Amt, [Discount UOM] = @UOM "
            + "WHERE ([Discount Id] = @DID); ";
        detailsDataAdapter.UpdateCommand.Connection = conn;
        detailsDataAdapter.UpdateCommand.Parameters.Add("@PCID", System.Data.SqlDbType.Int, 4, "Project Customer UBF Id");
        detailsDataAdapter.UpdateCommand.Parameters.Add("@Type", SqlDbType.Int, 4, "Discount Type");
        detailsDataAdapter.UpdateCommand.Parameters.Add("@Amt", SqlDbType.Float, 8, "Discount Amt");
        detailsDataAdapter.UpdateCommand.Parameters.Add("@UOM", SqlDbType.NVarChar, 2, "Discount UOM");
        detailsDataAdapter.InsertCommand.Parameters.Add("@DID", System.Data.SqlDbType.Int, 4, "Discount Id");
        detailsDataAdapter.DeleteCommand = new SqlCommand();
        detailsDataAdapter.DeleteCommand.CommandText = "DELETE FROM [Project Customer Discount] "
            + " WHERE ([Discount Id] = @DID);";
        detailsDataAdapter.DeleteCommand.Connection = conn;
        detailsDataAdapter.DeleteCommand.Parameters.Add("@DID", System.Data.SqlDbType.Int, 4, "Discount Id");
    }
