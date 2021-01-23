    Public Sub VerticalBarHide(ByVal grd As KryptonExtendedGrid, ByVal colname As String(), ByVal e As System.Drawing.Graphics)
        Dim rectHeader As Rectangle
        grd.EnableHeadersVisualStyles = False
        Dim bgColor As Color
        bgColor = grd.ColumnHeadersDefaultCellStyle.BackColor
        For Each name As String In colname
            rectHeader = grd.GetCellDisplayRectangle(grd.Columns(name).Index, -1, True)
            rectHeader.X = rectHeader.X + rectHeader.Width - 2
            rectHeader.Y += 1
            rectHeader.Width = 2 * 2
            rectHeader.Height -= 2
            e.FillRectangle(New SolidBrush(bgColor), rectHeader)
        Next
    End Sub
