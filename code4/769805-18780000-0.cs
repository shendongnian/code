    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_GRAYED As Integer = &H1
    
    <DllImport("user32.dll")> _
    Private Shared Function GetSystemMenu(hWnd As IntPtr, bRevert As Boolean) As IntPtr
    End Function
    
    <DllImport("user32.dll")> _
    Private Shared Function EnableMenuItem(hMenu As IntPtr, wIDEnableItem As Integer, wEnable As Integer) As Integer
    End Function
    
    Public Sub EnableDisable(form As Form, isEnable As Boolean)
        EnableMenuItem(GetSystemMenu(form.Handle, isEnable), SC_CLOSE, MF_GRAYED)
    End Sub
