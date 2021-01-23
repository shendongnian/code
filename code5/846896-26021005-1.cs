        ''' <summary>
        ''' Simulate key down event on Windows machine
        ''' </summary>
        ''' <param name="nCode">key</param>
        ''' <remarks></remarks>
        Public Sub SetKeyDown(ByVal nCode As Integer)
            Dim vKey As Byte = Convert.ToByte(nCode)
            Dim scanCode As Integer = MapVirtualKey(vKey, 0)
            Dim ret As Integer = keybd_event(vKey, CByte(scanCode), KEYEVENTF_EXTENDEDKEY Or 0, IntPtr.Zero)
        End Sub
    
        ''' <summary>
        ''' Simulate key up event on Windows machine
        ''' </summary>
        ''' <param name="nCode">key</param>
        ''' <remarks></remarks>
        Public Sub SetKeyUp(ByVal nCode As Integer)
            Dim vKey As Byte = Convert.ToByte(nCode)
            Dim scanCode As Integer = MapVirtualKey(vKey, 0)
            Dim ret As Integer = keybd_event(vKey, CByte(scanCode), KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP, IntPtr.Zero)
        End Sub
