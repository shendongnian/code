    Public Class ScrollBarInfo
    <System.Runtime.InteropServices.DllImport("user32")> _
    Private Shared Function GetScrollInfo(hwnd As IntPtr, nBar As Integer, ByRef scrollInfo As SCROLLINFO) As Integer
    End Function
    Private Shared scrollInf As New SCROLLINFO()
    Private Structure SCROLLINFO
        Public cbSize As Integer
        Public fMask As Integer
        Public min As Integer
        Public max As Integer
        Public nPage As Integer
        Public nPos As Integer
        Public nTrackPos As Integer
    End Structure
    Private Shared Sub Get_ScrollInfo(control As Control)
        scrollInf = New SCROLLINFO()
        scrollInf.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(scrollInf)
        scrollInf.fMask = &H10 Or &H1 Or &H2
        GetScrollInfo(control.Handle, 1, scrollInf)
    End Sub
    Public Shared Function ReachedBottom(control As Control) As Boolean
        Get_ScrollInfo(control)
        Return scrollInf.max = scrollInf.nTrackPos + scrollInf.nPage
    End Function
    Public Shared Function ReachedTop(control As Control) As Boolean
        Get_ScrollInfo(control)
        Return scrollInf.nTrackPos < 0
    End Function
    Public Shared Function IsAtBottom(control As Control) As Boolean
        Get_ScrollInfo(control)
        Return scrollInf.max = (scrollInf.nTrackPos + scrollInf.nPage) - 1
    End Function
    Public Shared Function IsAtTop(control As Control) As Boolean
        Get_ScrollInfo(control)
        Return scrollInf.nTrackPos = 0
    End Function
    End Class
