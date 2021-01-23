    SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@QuestionList";
                parameter.SqlDbType = System.Data.SqlDbType.Structured;
                parameter.Value = myDataTable;
                command.Parameters.Add(parameter); 
