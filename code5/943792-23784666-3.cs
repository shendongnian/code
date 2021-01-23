    Public Class PictureBoxEx
        Inherits PictureBox
        Private m_DefaultControl As Control
        Public Property DefaultControl() As Control
            Get
                Return m_DefaultControl
            End Get
            Set
                m_DefaultControl = Value
            End Set
        End Property
    End Class
