        Public Class SharpPanel : Inherits Panel
          Sub New()
            Padding = New Padding(2)
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            SetStyle(ControlStyles.ResizeRedraw, True)
            SetStyle(ControlStyles.UserPaint, True)
            SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            SetStyle(ControlStyles.ContainerControl, True)
            SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            SetStyle(ControlStyles.ContainerControl, True)
            Width = 100
            Height = 100
            TabStop = False
         End Sub
         Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim p As Control = Me.Parent
            Dim gr As Graphics = p.CreateGraphics
            Dim rec As Rectangle = Me.ClientRectangle
            If Me.VerticalScroll.Visible Then
                rec.Width = rec.Width + SystemInformation.VerticalScrollBarWidth
            End If
            If Me.HorizontalScroll.Visible Then
                rec.Height = rec.Height + SystemInformation.HorizontalScrollBarHeight
            End If
            rec.Location = Me.Location
            rec.Inflate(1, 1)
            gr.DrawRectangle(New Pen(Color.Pink), rec)
    End sub
    End Class
