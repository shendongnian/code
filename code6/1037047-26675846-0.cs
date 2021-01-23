      var records = (from t1 in x12.InterchangeDataSet.Tables["PO1"].AsEnumerable()
                     join t2 in x12.InterchangeDataSet.Tables["DTM"].AsEnumerable() 
                     on t1.Field<string>("Loop_Id") 
                     equals (t2.Field<string>("Loop_Id") == null 
                        ? string.Emtpty : t2.Field<string>("Loop_Id"))
                    select new{A = t1.Field<string>("PO101"),B=t2.Field<string>("DTM02")});
