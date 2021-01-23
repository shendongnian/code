    Private Declare Function SendInput Lib "user32.dll" (ByVal nInputs As Integer, ByRef pInputs As INPUT_TYPE, ByVal cbSize As Integer) As Integer
    Const INPUT_MOUSE = 0
    Const MOUSEEVENTF_MOVE = &H1
    Public Structure MOUSEINPUT
        Public dx As Integer
        Public dy As Integer
        Public mouseData As Integer
        Public dwFlags As Integer
        Public dwtime As Integer
        Public dwExtraInfo As Integer
    End Structure
    Public Structure INPUT_TYPE
        Public dwType As Integer
        Public xi As MOUSEINPUT
    End Structure
