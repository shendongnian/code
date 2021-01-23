    Public Class MouseDetector
        Public Event MouseLeftButtonClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        Public Event MouseRightButtonClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        Private Delegate Function MouseHookCallback(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
        Private MouseHookCallbackDelegate As MouseHookCallback
        Private MouseHookID As Integer
    
        Public Sub New()
            If MouseHookID = 0 Then
                MouseHookCallbackDelegate = AddressOf MouseHookProc
                MouseHookID = SetWindowsHookEx(CInt(14), MouseHookCallbackDelegate, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly.GetModules()(0)), 0)
                If MouseHookID = 0 Then
                    'error
                End If
            End If
        End Sub
    
        Public Sub Dispose()
            If Not MouseHookID = -1 Then
                UnhookWindowsHookEx(MouseHookID)
                MouseHookCallbackDelegate = Nothing
            End If
            MouseHookID = -1
        End Sub
    
        Private Enum MouseMessages
            WM_LeftButtonDown = 513
            WM_LeftButtonUp = 514
            WM_LeftDblClick = 515
            WM_RightButtonDown = 516
            WM_RightButtonUp = 517
            WM_RightDblClick = 518
        End Enum
    
        <StructLayout(LayoutKind.Sequential)> Private Structure Point
            Public x As Integer
            Public y As Integer
        End Structure
    
        <StructLayout(LayoutKind.Sequential)> Private Structure MouseHookStruct
            Public pt As Point
            Public hwnd As Integer
            Public wHitTestCode As Integer
            Public dwExtraInfo As Integer
        End Structure
    
        <DllImport("user32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
        Private Shared Function CallNextHookEx(ByVal idHook As Integer, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
        End Function
    
        <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Private Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal HookProc As MouseHookCallback, ByVal hInstance As IntPtr, ByVal wParam As Integer) As Integer
        End Function
    
        <DllImport("user32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall, SetLastError:=True)> _
        Private Shared Function UnhookWindowsHookEx(ByVal idHook As Integer) As Integer
        End Function
    
        Private Function MouseHookProc(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
            If nCode < 0 Then
                Return CallNextHookEx(MouseHookID, nCode, wParam, lParam)
            End If
            Dim MouseData As MouseHookStruct = Marshal.PtrToStructure(lParam, GetType(MouseHookStruct))
            Select Case wParam
                Case MouseMessages.WM_LeftButtonUp
                    RaiseEvent MouseLeftButtonClick(Nothing, New MouseEventArgs(MouseButtons.Left, 1, MouseData.pt.x, MouseData.pt.y, 0))
                Case MouseMessages.WM_RightButtonUp
                    RaiseEvent MouseRightButtonClick(Nothing, New MouseEventArgs(MouseButtons.Right, 1, MouseData.pt.x, MouseData.pt.y, 0))
            End Select
            Return CallNextHookEx(MouseHookID, nCode, wParam, lParam)
        End Function
    End Class
    Private Sub MouseDetector_MouseLeftButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MouseDetector.MouseLeftButtonClick
            'MessageBox.Show("left")
    End Sub
