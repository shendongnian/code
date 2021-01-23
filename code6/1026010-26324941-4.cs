    Public Class MyForm
    
        Public Sub New()
            InitializeComponent()
             Me.Button1.Visible = _buttonVisibility
        End Sub
    
        Private _buttonVisibility As Boolean = True
    
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Property ButtonVisible As Boolean
            Get
                Return _buttonVisibility
            End Get
            Set(value As Boolean)
                _buttonVisibility = value
                Button1.Visible = value
            End Set
        End Property
    
    End Class
