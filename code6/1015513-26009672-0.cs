    Protected Sub grid_RowInserting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataInsertingEventArgs) Handles grdProyectos.RowInserting
            Dim grid As ASPxGridView = (TryCast(sender, ASPxGridView))
            Dim chk As CheckBox= grid.FindEditRowCellTemplateControl(grid.Columns("name_colum"), "nameCheckBox")
            Dim marcada as Boolean = chk.Checked
    End Sub
