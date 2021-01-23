        Public Enum MessageBoxResult As UInteger
            Ok = 1
            Cancel
            Abort
            Retry
            Ignore
            Yes
            No
            Close
            Help
            TryAgain
            ContinueOn
            Timeout = 32000
        End Enum
    
        Public Enum MessageBoxOptions As UInteger
            SystemModal = &H1000
            NoFocus = &H8000
            SetForeground = &H10000
            Topmost = &H40000
        End Enum
    
        <DllImport("user32.dll", EntryPoint:="MessageBoxW", SetLastError:=True, Charset:=CharSet.Unicode)> _
        Public Shared Function MessageBox(hwnd As IntPtr, _
          <MarshalAs(UnmanagedType.LPTStr)> lpText As String, _
          <MarshalAs(UnmanagedType.LPTStr)> lpCaption As String, _
          <MarshalAs(UnmanagedType.U4)> uType As MessageBoxOptions) As <MarshalAs(UnmanagedType.U4)> MessageBoxResult
        End Function
    
        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            MessageBox(IntPtr.Zero, TextBox2.Text, TextBox1.Text, MessageBoxButtons.OK Or MessageBoxOptions.SystemModal + MessageBoxOptions.Topmost + MessageBoxOptions.SetForeground + MessageBoxIcon.Information)
        End Sub
    End Class
