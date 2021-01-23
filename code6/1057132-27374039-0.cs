    Public Class Form1
        Public Sub New(Optional ByVal args As String() = Nothing)
            Me.InitializeComponent()
            Me.args = New Label With {.Dock = DockStyle.Fill, .Text = If((args Is Nothing), "(null)", String.Join(Environment.NewLine, args))}
            Me.Controls.Add(Me.args)
        End Sub
        <STAThread()>
        Public Shared Sub Main(Optional ByVal args As String() = Nothing)
            Application.EnableVisualStyles()
            Application.Run(New Form1(args))
        End Sub
        Private args As New Label
    End Class
