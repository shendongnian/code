        dtresult = dt1.Copy
        Dim ds As New DataSet
        ds.Tables.Add(dtresult )
        ds.Tables.Add(dt2)
        ds.Relations.Add("KeyRelation", dt2.Columns("Key"), dtresult .Columns("Key"))
        dtresult .Columns.Add("OTS2", System.Type.GetType("System.Int32"), "Parent.OTS2")
        dtresult .Columns.Add("OTS3", System.Type.GetType("System.Int32"), "Parent.OTS3")
        dtresult.AcceptChanges()
