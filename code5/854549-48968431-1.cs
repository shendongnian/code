    Imports System.Drawing.Drawing2D
    Public Class Form1
        Public Sub buttonBorderRadius(ByRef buttonObj As Object, ByVal borderRadiusINT As Integer)
            Dim p As New Drawing2D.GraphicsPath()
            p.StartFigure()
            'TOP LEFT CORNER
            p.AddArc(New Rectangle(0, 0, borderRadiusINT, borderRadiusINT), 180, 90)
            p.AddLine(40, 0, buttonObj.Width - borderRadiusINT, 0)
            'TOP RIGHT CORNER
            p.AddArc(New Rectangle(buttonObj.Width - borderRadiusINT, 0, borderRadiusINT, borderRadiusINT), -90, 90)
            p.AddLine(buttonObj.Width, 40, buttonObj.Width, buttonObj.Height - borderRadiusINT)
            'BOTTOM RIGHT CORNER
            p.AddArc(New Rectangle(buttonObj.Width - borderRadiusINT, buttonObj.Height - borderRadiusINT, borderRadiusINT, borderRadiusINT), 0, 90)
            p.AddLine(buttonObj.Width - borderRadiusINT, buttonObj.Height, borderRadiusINT, buttonObj.Height)
            'BOTTOM LEFT CORNER
            p.AddArc(New Rectangle(0, buttonObj.Height - borderRadiusINT, borderRadiusINT, borderRadiusINT), 90, 90)
            p.CloseFigure()
            buttonObj.Region = New Region(p)
        End Sub
        Private Sub Button1_Paint(sender As Object, e As PaintEventArgs) Handles Button1.Paint
            buttonBorderRadius(sender, 25)
        End Sub
        Private Sub Button2_Paint(sender As Object, e As PaintEventArgs) Handles Button2.Paint
            buttonBorderRadius(sender, 50)
        End Sub
    End Class
