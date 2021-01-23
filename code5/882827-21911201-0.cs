    Public Class CreditCardProcessor
        Public Function ValidateDetails As Boolean
            'check everything validates here and return True/False accoringly
        End Function
        Public Sub ProcessDetails
            If Not ValidateDetails Then
                Throw New Exception("Validation failed")
                Exit sub
            End If
            'Process the credit card here
        End Sub
    End Class
