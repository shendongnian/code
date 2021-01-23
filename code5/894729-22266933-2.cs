    Public Class XWizardControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        Protected Overrides Function CreateControlsInstance() As Control.ControlCollection
            Return New XWizardControlCollection(Me)
        End Function
        Private Class XWizardControlCollection
            Inherits DevExpress.XtraEditors.XtraUserControl.ControlCollection
            Public Sub New(owner As XWizardControl)
                MyBase.New(owner)
            End Sub
            Public Overrides Sub Add(ByVal value As Control)
                If (Not TypeOf value Is XWizardPage) Then
                    Throw New ArgumentException()
                End If
                MyBase.Add(value)
            End Sub
        End Class
    End Class
