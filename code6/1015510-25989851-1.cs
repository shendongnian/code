     var studentData = (from redt in RoundEndDateTable.AsEnumerable()
                       join st in StudentTable.AsEnumerable() 
                       on redt.Field<string>("strActivityName") 
                       equals st.Field<string>("strActivityName")
                       select new
                       {
                          actionName = st.ItemArray[0],
                          associateId  = st.ItemArray[1],
                          completedDate = st.ItemArray[2],
                          EndDate = redt.ItemArray[1],
                          DateDifference = DateTime.Parse(redt.ItemArray[1].ToString()) - 
                          DateTime.Parse(st.ItemArray[2].ToString())
                       });
