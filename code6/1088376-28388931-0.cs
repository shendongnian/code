    Public Class MyProxy
        Inherits ClientBase(of InterfaceDom)
        Implements InterfaceDom
        Public Function add(ByVal num1 as Integer, ByVal num2 as Integer) as Integer
            Return MyBase.Channel.Add(num1, num2)
        End Function
    End Class
