    Public Class XWizardControl
        Inherits DevExpress.XtraEditors.XtraUserControl
        <DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=True)> _
        Private Shared Function GetDCEx(ByVal hWnd As IntPtr, ByVal hrgnClip As IntPtr, ByVal flags As Integer) As IntPtr
        End Function
        Private Sub WmNcCalcSize(ByRef m As Message)
            If (m.WParam.ToInt32() = 0) Then
                Dim ncRect As RECT = DirectCast(m.GetLParam(GetType(RECT)), RECT)
                ncRect.top += 10
                ncRect.bottom -= 10
                Marshal.StructureToPtr(ncRect, m.LParam, False)
                m.Result = IntPtr.Zero
            ElseIf (m.WParam.ToInt32() = 1) Then
                Dim ncParams As NCCALCSIZE_PARAMS = DirectCast(m.GetLParam(GetType(NCCALCSIZE_PARAMS)), NCCALCSIZE_PARAMS)
                ncParams.rectProposed.top += 10
                ncParams.rectProposed.bottom -= 10
                Marshal.StructureToPtr(ncParams, m.LParam, False)
                m.Result = IntPtr.Zero
            Else
                MyBase.WndProc(m)
            End If
        End Sub
        Private Sub WmNcPaint(ByRef m As Message)
            Dim hDC As IntPtr = GetDCEx(m.HWnd, m.WParam, (DCX.WINDOW Or DCX.INTERSECTRGN Or DCX.CACHE Or DCX.CLIPSIBLINGS))
            If (hDC.ToInt32() <> 0) Then
                Using g As Graphics = Graphics.FromHdc(hDC)
                    g.Clear(Color.Red)
                End Using
                m.Result = IntPtr.Zero
            Else
                MyBase.WndProc(m)
            End If
        End Sub
        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            Select Case m.Msg
                Case WM_NCCALCSIZE : Me.WmNcCalcSize(m) : Exit Select
                Case WM_NCPAINT : Me.WmNcPaint(m) : Exit Select
                Case Else : MyBase.WndProc(m) : Exit Select
            End Select
        End Sub
        Public Const WM_NCCALCSIZE As Integer = 131
        Public Const WM_NCPAINT As Integer = 133
        <StructLayout(LayoutKind.Sequential)> _
        Private Structure RECT
            Public left As Integer
            Public top As Integer
            Public right As Integer
            Public bottom As Integer
        End Structure
        <StructLayout(LayoutKind.Sequential)> _
        Private Structure NCCALCSIZE_PARAMS
            Public rectProposed As RECT
            Public rectBeforeMove As RECT
            Public rectClientBeforeMove As RECT
            Public lppos As WINDOWPOS
        End Structure
        <StructLayout(LayoutKind.Sequential)> _
        Private Structure WINDOWPOS
            Public hwnd As IntPtr
            Public hWndInsertAfter As IntPtr
            Public x As Integer
            Public y As Integer
            Public cx As Integer
            Public cy As Integer
            Public flags As UInteger
        End Structure
        Private Enum DCX As Integer
            CACHE = &H2
            CLIPCHILDREN = &H8
            CLIPSIBLINGS = &H10
            EXCLUDERGN = &H40
            EXCLUDEUPDATE = &H100
            INTERSECTRGN = &H80
            INTERSECTUPDATE = &H200
            LOCKWINDOWUPDATE = &H400
            NORECOMPUTE = &H100000
            NORESETATTRS = &H4
            PARENTCLIP = &H20
            VALIDATE = &H200000
            WINDOW = &H1
        End Enum
    End Class
