updatechild(objCas.ECC_Decision, PromatCon.ECC_Decision.Where(Function(c) c.rid = objCas.rid And Not objCas.ECC_Decision.Select(Function(x) x.dcid).Contains(c.dcid)).toList)
Sub updatechild(Of Ety)(amList As ICollection(Of Ety), rList As ICollection(Of Ety))
        If amList IsNot Nothing Then
            For Each obj In amList
                Dim x = PromatCon.Entry(obj).GetDatabaseValues()
                If x Is Nothing Then
                    PromatCon.Entry(obj).State = EntityState.Added
                Else
                    PromatCon.Entry(obj).State = EntityState.Modified
                End If
            Next
        End If
        If rList IsNot Nothing Then
            For Each obj In rList.ToList
                PromatCon.Entry(obj).State = EntityState.Deleted
            Next
        End If
End Sub
    PromatCon.SaveChanges()
