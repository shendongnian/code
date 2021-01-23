    If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
    
    With Me.YourDataGridView
    	If .Columns(e.ColumnIndex).Name = "YourDataGridViewImageColumnName" Then
    		If .Rows(e.RowIndex).Cells("IsEditable").Value Then
    			e.Value = <code to get edit.png>
    		Else
    			e.Value = <code to get disable_edit.png>
    		End If
    	End If
    End With
