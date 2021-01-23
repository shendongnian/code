    ''' <summary>
    ''' The Backcolor to fill the ToolStrip ProgressBar.
    ''' </summary>
    Private ProgressBar_BackColor As Brush = New SolidBrush(Color.FromArgb(120, 147, 73))
    ''' <summary>
    ''' The ForeColor to fill the ToolStrip ProgressBar.
    ''' </summary>
    Private ProgressBar_ForeColor As Brush = New SolidBrush(Color.Black)
    ''' <summary>
    ''' Draws a border effect inside the bounds of the ProgressBar.
    ''' </summary>
    Private ProgressBar_Border As Single = 0
    ''' <summary>
    ''' Indicates the StringFormat of the ProgressBar Text.
    ''' </summary>
    Private ProgressBar_Text_Format As StringFormat =
        New StringFormat With {.Alignment = Drawing.StringAlignment.Center,
                               .Trimming = StringTrimming.EllipsisCharacter}
    Public Sub New()
        ' Necessary call to the designer.
        InitializeComponent()
        ' Set the Style of the ToolStripProgesssBar (For be able to fill the progressbar with a custom color).
        GetType(Control).GetMethod("SetStyle", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance).
                         Invoke(ToolStripProgressBar1.ProgressBar,
                                New Object() {ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True})
    End Sub
    ' ProgressBarStatus [Paint]
    Private Sub ProgressBarStatus_Paint(sender As Object, e As PaintEventArgs) _
    Handles ToolStripProgressBar1.Paint
        ' Fill the progressbar
        Select Case sender.style
            Case ProgressBarStyle.Continuous
                ' The ProgressBar Rectangle.
                Dim ProgressBarRect As RectangleF =
                    New RectangleF(ProgressBar_Border / 2, ProgressBar_Border / 2,
                                   CSng(sender.Value / sender.Maximum) * CSng(sender.ProgressBar.Width - ProgressBar_Border),
                                   sender.ProgressBar.Height - ProgressBar_Border)
                e.Graphics.FillRectangle(ProgressBar_BackColor, ProgressBarRect)
            Case ProgressBarStyle.Blocks
                ' The Width of each block.
                Dim BlockWidth As Integer = 10
                ' The space between each block.
                Dim BlockSpace As Integer = 1
                ' The ProgressBar Rectangle.
                Dim ProgressBarRect As Rectangle =
                    New Rectangle(0, 0, BlockWidth, sender.ProgressBar.Height - 4)
                ' Calculate the block count.
                Dim PercentDone As Single = CSng(sender.ProgressBar.Value / sender.ProgressBar.Maximum)
                Dim valueLength As Single = PercentDone * CSng(sender.ProgressBar.Width)
                Dim BlockCount As Integer = CInt(valueLength / (BlockWidth + BlockSpace) + 0.5F)
                ProgressBarRect.Offset(2, 2)
                For i As Integer = 0 To BlockCount - 1
                    e.Graphics.FillRectangle(ProgressBar_BackColor, ProgressBarRect)
                    ProgressBarRect.Offset(BlockWidth + BlockSpace, 0)
                Next
                ControlPaint.DrawBorder3D(e.Graphics, sender.ProgressBar.ClientRectangle, Border3DStyle.SunkenOuter)
        End Select
        ' Draw the Text
        Dim TextBounds As Rectangle = sender.ProgressBar.Bounds
        TextBounds.Inflate(0, 4) ' Correct the Text position.
        Using fnt As New Font(CType(sender.ProgressBar.Font.FontFamily, FontFamily),
                              CSng(sender.ProgressBar.Font.SizeInPoints) + 1,
                              FontStyle.Bold)
            e.Graphics.DrawString(sender.ProgressBar.Value, fnt, ProgressBar_ForeColor, TextBounds, ProgressBar_Text_Format)
        End Using
    End Sub
