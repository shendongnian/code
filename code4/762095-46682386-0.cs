    Public Class IsIntegerGreatherOrEqualThan
            Inherits ValidationAttribute
            Private otherPropertyName As String
            Private errorMessage As String
            Public Sub New(ByVal otherPropertyName As String, ByVal errorMessage As String)
                Me.otherPropertyName = otherPropertyName
                Me.errorMessage = errorMessage
            End Sub
            Protected Overrides Function IsValid(thisPropertyValue As Object, validationContext As ValidationContext) As ValidationResult
                Dim otherPropertyTestedInfo = validationContext.ObjectType.GetProperty(Me.otherPropertyName)
                If (otherPropertyTestedInfo Is Nothing) Then
                    Return New ValidationResult(String.Format("unknown property {0}", Me.otherPropertyName))
                End If
                Dim otherPropertyTestedValue = otherPropertyTestedInfo.GetValue(validationContext.ObjectInstance, Nothing)
                If (thisPropertyValue Is Nothing) Then
                    Return ValidationResult.Success
                End If
                ''  Compare values
                If (CType(thisPropertyValue, Integer) >= CType(otherPropertyTestedValue, Integer)) Then
                    Return ValidationResult.Success
                End If
                ''  Wrong
                Return New ValidationResult(FormatErrorMessage(errorMessage))
            End Function
        End Class
