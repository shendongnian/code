    var result = (from d1 in dtTable1.AsEnumerable()
                          join d2 in dtTable2.AsEnumerable() on new { TransID = d1["TransID"], BookingID = d1["BookingID"], BookingStatus =d1["BookingStatus"] } equals new { TransID = d2["TransID"], BookingID = d2["BookingID"], BookingStatus =d2["BookingStatus"] } into leftJoin
                          from d2 in leftJoin.DefaultIfEmpty()
                          where d2 == null
                          select dtResult.LoadDataRow(new object[]
                            {
                            d1["TransID"],
                            d1["BookingID"],                       
                            d1["BookingStatus"],
                            d1["BookingType"]
                            
                            }, false)).Union(
                            from dt2 in dtTable2.AsEnumerable()
                            join dt1 in dtTable1.AsEnumerable() on new { TransID = dt2["TransID"], 
                            BookingID = dt2["BookingID"] } equals new { TransID = dt1["TransID"], BookingID = dt1["BookingID"] } into rightJoin
                            from dt1 in rightJoin.DefaultIfEmpty()
                            where dt1 == null
                            select dtResult.LoadDataRow(new object[]
                            {
                            dt2["TransID"],
                            dt2["BookingID"],                       
                            dt2["BookingStatus"],
                            dt2["BookingType"]
                            }, false));
            result.CopyToDataTable();
 
