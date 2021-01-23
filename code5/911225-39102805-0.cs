    SqlParameter paramoutput = new SqlParameter()
    {
       ParameterName = "Result",
       // Value = "", no need
       SqlDbType = System.Data.SqlDbType.BigInt,
       // Size = 100, no need
       Direction = System.Data.ParameterDirection.Output
    };
    
    var mydata = (dataContext as IObjectContextAdapter).ObjectContext
                 .ExecuteStoreQuery<long>("exec Save @MarkupId, @ApiId, @MainBranchId, @Title, @Markup, @IsPercentage, @IsDomestic, @CreatedOn, @CreatedBy, @ModifiedOn, @ModifiedBy, @IsActive, @Result out",
                     new SqlParameter("@MarkupId", generalMarkupModel.Id),
                     new SqlParameter("@ApiId", generalMarkupModel.ApiId),
                     new SqlParameter("@MainBranchId", generalMarkupModel.MainBranchId),
                     new SqlParameter("@Title", generalMarkupModel.Title),
                     new SqlParameter("@Markup", generalMarkupModel.Markup),
                     new SqlParameter("@IsPercentage", generalMarkupModel.IsPercentage),
                     new SqlParameter("@IsDomestic", generalMarkupModel.IsDomestic),
                     new SqlParameter("@IsActive", generalMarkupModel.IsActive),
                     new SqlParameter("@CreatedOn", DateTime.Now),
                     new SqlParameter("@CreatedBy", "ajc"),
                     new SqlParameter("@ModifiedOn", DateTime.Now),
                     new SqlParameter("@ModifiedBy", "ajm"),
                     paramoutput);
    
    // here, the mydata, is of type ObjectResult<long> which you should iterate it to get underlying IDataReader iterated and closed. Then you can use output parameters. So, add this line:
    var returnedId = mydata.FirstOrDefault();
    // now, the output parameter is available:
    Id = Convert.ToInt64(paramoutput.Value.ToString());
