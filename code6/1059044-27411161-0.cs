    //<DllImport("User32.dll")>_
    //Public Shared Function GetWindowDC(ByVal hWnd As IntPtr) As IntPtr
    //End Function
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Dim HDC As IntPtr
        If m.Msg = 133 Then
            HDC = GetWindowDC(m.HWnd)
            If HDC <> IntPtr.Zero Then
                Using g As Graphics = Graphics.FromHdc(HDC)
                    g.DrawRectangle(Pens.Blue, 0, 0, Me.Width - 1, Me.Height - 1)
                End Using
            End If
            Return
        End If
        MyBase.WndProc(m)
    End Sub
