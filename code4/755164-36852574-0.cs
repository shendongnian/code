    Protected Sub gMaterias_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles gMaterias.RowCancelingEdit
        gMaterias.EditIndex = -1
        BindData()
    End Sub
    Protected Sub gMaterias_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles gMaterias.RowEditing
        gMaterias.EditIndex = e.NewEditIndex
        BindData()
    End Sub
    Protected Sub gMaterias_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles gMaterias.RowUpdating
        lError.Visible = False
        lError.Text = ""
        Dim idMateria As Integer = e.Keys(0)
        Dim row As GridViewRow = gMaterias.Rows(e.RowIndex)
        Dim tbl As DataTable = Session("Materias")
        tbl.Rows(row.DataItemIndex)("universidad") = CType(gMaterias.Rows(e.RowIndex).Cells(5).Controls(0), TextBox).Text
        Dim calf = CType(gMaterias.Rows(e.RowIndex).Cells(6).Controls(0), TextBox).Text
        If IsNumeric(calf) Then
            tbl.Rows(row.DataItemIndex)("calificacion") = calf
        Else
            lError.Visible = True
            lError.Text = "La calificación no es válida"
        End If
        gMaterias.EditIndex = -1
        BindData()
    End Sub
