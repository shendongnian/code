    List<int> vals = new List<int> {1,2,6};
    
    var qry = from rec1 in Table1
              join rec2 in Table2 on rec1.Column1 equals rec2.Column2 into ljT2
              from rec2 in ljT2.DefaultIfEmpty()  //Handle left join
              join rec3 in Table3 on rec1.Column1 equals rec3.Column3
              where vals.Contains(rec3.Column4)
              select new {
                    Test1 = rec1.Column1,
                    Test2 = 1,
                    Test3 = rec2 == null?null:rec2.Column2, //Must allow for rec2 to be null
                    Test4 = rec3.Column5,
                    Test5 = rec3.Column6
                }
    qry = qry.Distinct();
