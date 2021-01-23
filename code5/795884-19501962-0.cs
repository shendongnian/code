    Private _progressBar_backcolor As SolidBrush = New SolidBrush(Color.Red)
    Public Property ProgressBar_BackColor As Color
        Get
            Return _progressBar_backcolor.Color
        End Get
        Set(ByVal value As Color)
            _progressBar_backcolor = New SolidBrush(value)
        End Set
    End Property
