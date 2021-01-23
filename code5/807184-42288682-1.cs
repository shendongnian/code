    Friend Function GetDepartment(ByVal DateFrom As String, ByVal DateTo As String)
        Dim xSQL As New System.Text.StringBuilder
        xSQL.AppendLine("SELECT SUM(a.Quantity ) AS quantity, ")
        xSQL.AppendLine("    SUM(a.TotalAmount ) AS totalamount, ")
        xSQL.AppendLine("    a.ProductID, ")
        xSQL.AppendLine("    c.DepartmentID, ")
        xSQL.AppendLine("    a.LongName, ")
        xSQL.AppendLine("    c.Department ")
        xSQL.AppendLine("FROM Transaction01Details a ")
        xSQL.AppendLine("    INNER JOIN Product00header b ON a.ProductID = b.ProductID ")
        xSQL.AppendLine("    INNER JOIN Department00header c ON b.DepartmentID = c.DepartmentID ")
        xSQL.AppendLine("WHERE (a.Tag4 = 'i') ")
        xSQL.AppendLine("    AND (a.TransDate BETWEEN @Date1 AND @Date2) ")
        xSQL.AppendLine("GROUP BY a.ProductID ")
        xSQL.AppendLine("ORDER BY a.LongName ")
        ' Lambda Expression
        Dim lambda = cn.Query(xSQL.ToString, New With {.Date1 = DateFrom, .Date2 = DateTo}).Select(Function(p) New With {.ProductID = CStr(p.ProductID), _
                                                                                        .DepartmentID = CStr(p.DepartmentID), _
                                                                                        .LongName = CStr(p.LongName), _
                                                                                        .Department = CStr(p.Department), _
                                                                                        .Quantity = CDec(p.Quantity), _
                                                                                        .TotalAmount = CDec(p.TotalAmount)}).ToList
        ' Linq Expression
        Dim linq = (From p In cn.Query(xSQL.ToString, New With {.Date1 = DateFrom, .Date2 = DateTo})
                    Select New With {.ProductID = CStr(p.ProductID), ' Note, All p.Object is also dynamic
                                     .DepartmentID = CStr(p.DepartmentID), 
                                     .LongName = CStr(p.LongName),
                                     .Department = CStr(p.Department),
                                     .Quantity = CDec(p.Quantity),
                                     .TotalAmount = CDec(p.TotalAmount)}).ToList
        
        ' in linq, no need to declare function and also no need to put this  --- >  _ to continue the statement
    End Function
