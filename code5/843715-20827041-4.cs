    Namespace ClassLibraryVB
        Public Class ClassVBInCSharp
            Inherits ClassCSharp
            Property Test2 As Integer
    
            Protected Overrides Sub Test()
                Test2 = MyBase.MyProperty
            End Sub
        End Class
    End Namespace
