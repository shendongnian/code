    Public Class TestClass
        Public Sub New(ByVal v1 As String, ByVal v2 As String)
            Value1 = v1
            Value2 = v2
        End Sub
        Public Property Value1() As String
        Public Property Value2() As String
    End Class
        Dim tc As New List(Of TestClass)
        tc.Add(New TestClass("aa", "bb"))
        tc.Add(New TestClass("cc", "dd"))
        tc.Add(New TestClass("ee", "ff"))
