    var result= _unitOfWork.SqlQuery<Result>("sp_Get @FromDateTime, @ToDateTime, @CountyId",
                         new SqlParameter("FromDateTime", SqlDbType.DateTime) { Value = Request.FromDateTime },
                         new SqlParameter("ToDateTime", SqlDbType.DateTime) { Value = Request.TripToDateTime },
                         new SqlParameter("CountyId", SqlDbType.Int) { Value = Convert.ToInt32(Request.County) }
           ).ToList();
