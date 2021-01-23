    Public Class UITabControl
        Inherits TabControl
        Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
            Using brush As New SolidBrush(Me.ForeColor)
                Using format As New StringFormat() With {.LineAlignment = StringAlignment.Center}
                    Select Case Me.Alignment
                        Case TabAlignment.Left
                            format.Alignment = StringAlignment.Near
                        Case TabAlignment.Top
                            format.Alignment = StringAlignment.Far
                    End Select
                    format.FormatFlags = (format.FormatFlags Or StringFormatFlags.NoWrap)
                    Dim rect As Rectangle = e.Bounds
                    rect.X += 3
                    rect.Width -= 6
                    e.Graphics.DrawString(Me.TabPages(e.Index).Text, Me.Font, brush, rect, format)
                End Using
            End Using
            MyBase.OnDrawItem(e)
        End Sub
    End Class
