    <System.Runtime.InteropServices.DllImport("User32")>
    Private Shared Function ShowWindow(
             ByVal hwnd As IntPtr,
             ByVal nCmdShow As Integer
    ) As Integer
    End Function
    <System.Runtime.InteropServices.DllImport("User32.dll")>
    Private Shared Function FindWindowEx(
            ByVal hwndParent As IntPtr,
            ByVal hwndChildAfter As IntPtr,
            ByVal strClassName As String,
            ByVal strWindowName As String
    ) As IntPtr
    End Function
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function GetWindowThreadProcessId(
            ByVal hWnd As IntPtr,
            ByRef ProcessId As Integer
    ) As Integer
    End Function
    Public Enum WindowState As Integer
        ''' <summary>
        ''' Hides the window and activates another window.
        ''' </summary>
        Hide = 0I
        ''' <summary>
        ''' Activates and displays a window. 
        ''' If the window is minimized or maximized, the system restores it to its original size and position.
        ''' An application should specify this flag when displaying the window for the first time.
        ''' </summary>
        Normal = 1I
        ''' <summary>
        ''' Activates the window and displays it as a minimized window.
        ''' </summary>
        ShowMinimized = 2I
        ''' <summary>
        ''' Maximizes the specified window.
        ''' </summary>
        Maximize = 3I
        ''' <summary>
        ''' Activates the window and displays it as a maximized window.
        ''' </summary>      
        ShowMaximized = Maximize
        ''' <summary>
        ''' Displays a window in its most recent size and position. 
        ''' This value is similar to <see cref="WindowVisibility.Normal"/>, except the window is not actived.
        ''' </summary>
        ShowNoActivate = 4I
        ''' <summary>
        ''' Activates the window and displays it in its current size and position.
        ''' </summary>
        Show = 5I
        ''' <summary>
        ''' Minimizes the specified window and activates the next top-level window in the Z order.
        ''' </summary>
        Minimize = 6I
        ''' <summary>
        ''' Displays the window as a minimized window. 
        ''' This value is similar to <see cref="WindowVisibility.ShowMinimized"/>, except the window is not activated.
        ''' </summary>
        ShowMinNoActive = 7I
        ''' <summary>
        ''' Displays the window in its current size and position.
        ''' This value is similar to <see cref="WindowVisibility.Show"/>, except the window is not activated.
        ''' </summary>
        ShowNA = 8I
        ''' <summary>
        ''' Activates and displays the window. 
        ''' If the window is minimized or maximized, the system restores it to its original size and position.
        ''' An application should specify this flag when restoring a minimized window.
        ''' </summary>
        Restore = 9I
        ''' <summary>
        ''' Sets the show state based on the SW_* value specified in the STARTUPINFO structure 
        ''' passed to the CreateProcess function by the program that started the application.
        ''' </summary>
        ShowDefault = 10I
        ''' <summary>
        ''' <b>Windows 2000/XP:</b> 
        ''' Minimizes a window, even if the thread that owns the window is not responding. 
        ''' This flag should only be used when minimizing windows from a different thread.
        ''' </summary>
        ForceMinimize = 11I
    End Enum
    Private Sub SetWindowState(ByVal ProcessName As String,
                               ByVal WindowState As WindowState,
                               Optional ByVal Recursivity As Boolean = False)
        If ProcessName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) Then
            ProcessName = ProcessName.Remove(ProcessName.Length - ".exe".Length)
        End If
        Dim pHandle As IntPtr = IntPtr.Zero
        Dim pID As Integer = 0I
        Dim Processes As Process() = Process.GetProcessesByName(ProcessName)
        ' If any process matching the name is found then...
        If Processes.Count = 0 Then
            Exit Sub
        End If
        For Each p As Process In Processes
            Do Until pID = p.Id ' Check all windows.
                ' Get child handle of window who's handle is "pHandle".
                pHandle = FindWindowEx(IntPtr.Zero, pHandle, Nothing, Nothing)
                ' Get ProcessId from "pHandle".
                GetWindowThreadProcessId(pHandle, pID)
                ' If the ProcessId matches the "pID" then...
                If pID = p.Id Then
                    ShowWindow(pHandle, WindowState)
                    If Not Recursivity Then
                        Exit For
                    End If
                End If
            Loop
        Next p
    End Sub
