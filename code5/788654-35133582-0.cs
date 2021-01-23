    Private Sub CreateControl()
        Dim vw As Control
        vw = CType(LoadControl("~/View01.ascx"), View01)
        vw.ID = "View_Dyn"
        PlaceHolder1.Controls.Clear()
        PlaceHolder1.Controls.Add(vw)
    End Sub
