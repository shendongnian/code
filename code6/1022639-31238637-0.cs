    Public Class Abc
        Private _comClassInstance As Object
    
        Public Sub New()
            _comClassInstance = CreateObject("ClassName")
        End Sub
    
        Public Sub ComClassMethod()
            _comClassInstance.ComClassMethod()
        End Sub
        Public Function ComClassFMethod(param As String) As Integer
            Return _comClassInstance.ComClassFMethod(param)
        End Function 
    End Class
