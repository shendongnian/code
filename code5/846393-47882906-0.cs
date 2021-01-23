    var studentIdParameter = new SqlParameter
    {
         ParameterName = "studentId",
         Direction = ParameterDirection.Input,
         SqlDbType = SqlDbType.BigInt,
         Value = studentId
     };
     var results = Context.Database.SqlQuery<StudentChapterCompletionViewModel>(
                    "exec dbo.sp_StudentComplettion @studentId",
                     studentIdParameter
                    ).ToList();
