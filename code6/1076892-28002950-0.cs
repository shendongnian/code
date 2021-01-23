    Sub Main()
        ' http://forums.asp.net/t/1826584.aspx?Select+DataRow+with+latest+date+using+LINQ
        dt.Columns.Add("ID", Type.GetType("System.Int32"))
        dt.Columns.Add("Name")
        dt.Columns.Add("punchdate", Type.GetType("System.DateTime"))
        dt.Rows.Add(100, "Rajesh", "01-jan-2014")
        dt.Rows.Add(101, "Rajesh", "01-feb-2014")
        dt.Rows.Add(102, "Rajesh", "01-apr-2014")
        dt.Rows.Add(103, "Rajesh", "01-sep-2014")
        dt.Rows.Add(104, "John", "15-sep-2014")
        ' Dim Max1 = rows.Max(Function(r) r.Field(Of DateTime)("punchdate"))
        Dim myLINQ = From grp In From dt In dt.AsEnumerable() _
                                 Group dt By GRP = dt.Field(Of String)("Name") Into Group _
                                 Select New With { _
                                     Key .ID = Group.Max(Function(T) T.Field(Of Int32)("ID")), _
                                     Key .Name = GRP, _
                                     Key .[Date] = Group.Max(Function(T) T.Field(Of DateTime)("punchdate")) _
                                                }
        Debug.WriteLine("=======================================")
        For Each g In myLINQ
            ' Debug.WriteLine("Numbers that match '{0}':", g.Name)
            Debug.WriteLine(g.Name & "----->" + g.Date.ToString)
        Next
    End Sub
