     Private Sub dataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
	If DataGridView1.Columns(e.ColumnIndex).Name = "ColCheck" Then
            If DataGridView1.Rows(e.RowIndex).Cells("ColCheck").Value = True Then
		Dim isChecked As Boolean = DirectCast(dataGridView1(e.ColumnIndex, e.RowIndex).FormattedValue, [Boolean])
		If isChecked Then
                  DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
		End If
	End If
      End If
     End Sub
