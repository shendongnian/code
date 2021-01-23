    Private values As List(Of String)
    Private Sub dgView_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles gridView1.CustomSummaryCalculate
        If Not e.IsTotalSummary Then
            Exit Sub
        End If
        Const fieldName$ = "KONTOSIFRA"
        Dim summaryItem As GridSummaryItem = TryCast(e.Item, GridSummaryItem)
        If summaryItem Is Nothing AndAlso summaryItem.FieldName <> fieldName$ Then
            Exit Sub
        End If
        Select Case e.SummaryProcess
            Case CustomSummaryProcess.Start
                values = New List(Of String)
            Case CustomSummaryProcess.Calculate
                Dim edit As RepositoryItemLookUpEdit = DirectCast(dgView.Columns(fieldName$).ColumnEdit, RepositoryItemLookUpEdit)
                Dim value As Object = edit.GetDisplayValueByKeyValue(e.FieldValue)
                If Not IsNothing(value) Then
                    values.Add(value)
                End If
            Case CustomSummaryProcess.Finalize
                If values.Count > 0 Then
                    e.TotalValue = String.Join(", ", values.Distinct())
                End If
        End Select
    End Sub
