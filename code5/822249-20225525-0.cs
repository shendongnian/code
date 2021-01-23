    var custNum = new SqlParameter {ParameterName = "CustNum", Value = CustomerNum};
    var primaryDisc = new SqlParameter { ParameterName = "PrimaryDisc", Value = 0 };
    var secondaryDisc = new SqlParameter { ParameterName = "SecondaryDisc", Value = 0 };
    
    var results = _MiscContext.Database.SqlQuery<TempTechDisciplines>(
                 "exec sp_getTechnicalDiscipline @CustNum, @PrimaryDisc,
                  @SecondaryDisc",
                  custNum,primaryDisc,secondaryDisc).ToList<TempTechDisciplines>();
