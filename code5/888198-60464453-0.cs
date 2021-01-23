                var param = new SqlParameter
                {
                    ParameterName = "@JobStatus",
                    DbType = DbType.String,
                    Size = 30,
                    Direction = System.Data.ParameterDirection.Output
                };
    
                var result = this.etlContext.Database.SqlQuery<string>("EXEC dbo.up_GetJobStatus @JobStatus=@JobStatus OUTPUT", param);
                string JobStatus = param.Value.ToString();
