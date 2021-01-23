    DbCommand dbCommand = pbkDB.GetSqlStringCommand(@"Update tblCtStateChargeSentenceMeasures set (
      MeasureCode = @MeasureCode 
    , UpdateUserId = @UpdateUserId
    , UpdateDate = @UpdateDate)
     where ChargeCode = @ChargeCode", 
    );
    dcCommand.Parameter.Add("ChargeCode",ChargeCode);
    dcCommand.Parameter.Add("MeasureCode",MeasureCode);
    dcCommand.Parameter.Add("UpdateUserId",UpdateUserId);
    dcCommand.Parameter.Add("UpdateDate",UpdateDate);
    
    pbkDB.ExecuteNonQuery(dbCommand);
