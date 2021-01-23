    Public Sub set_AcceptButton(ByVal value As IButtonControl)
      If (Not Me.AcceptButton Is value) Then
        MyBase.Properties.SetObject(Form.PropAcceptButton, value)
        Me.UpdateDefaultButton
      End If
    End Sub
    Public Sub set_CancelButton(ByVal value As IButtonControl)
      MyBase.Properties.SetObject(Form.PropCancelButton, value)
      If ((Not value Is Nothing) AndAlso (value.DialogResult = DialogResult.None)) Then
        value.DialogResult = DialogResult.Cancel
      End If
    End Sub
