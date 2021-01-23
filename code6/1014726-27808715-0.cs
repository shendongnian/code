    Imports System.ComponentModel.DataAnnotations
    
    Public Class Form1
    
        Private Shadows Sub Load() Handles MyBase.Load
    
            Dim Test As New Test
            Test.MyInt32 = Int32.MaxValue
    
            MessageBox.Show(Test.MyInt32) ' Result: 1, because it got set to this in the exception handler of the property setter
    
        End Sub
    
    End Class
    
    Public Class Test
    
        <Range(1, 10, errormessage:="something")>
        Public Property MyInt32 As Integer
            Get
                Return Me._MyInt32
            End Get
            Set(ByVal value As Integer)
                Try
                    Validator.ValidateProperty(value, New ValidationContext(Me, Nothing, Nothing) With {.MemberName = "MyInt32"})
                    Me._MyInt32 = value
                Catch ex As ValidationException
                    Me._MyInt32 = 1
                End Try
            End Set
        End Property
    
        Private _MyInt32 As Integer
    
    End Class
