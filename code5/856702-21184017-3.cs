    Me.personColumn.ImageGetter =  Function (object rowObject) As Object
                                       Dim p As Person = DirectCast(rowObject, Person)
                                       If "AEIOU".Contains(p.Name.Substring(0, 1)) Then
                                           Return 0
                                       Else If p.Name.CompareTo("N") < 0 Then
                                           Return 1
                                       Else
                                           Return 2
                                       End If
                                   End Function
