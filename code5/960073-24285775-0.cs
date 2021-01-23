    Public Shared Function SplitByLetter(text As String) As String()
        Dim list As New List(Of String)
        Dim sb As New System.Text.StringBuilder()
        For Each chr As Char In text.SkipWhile(AddressOf Char.IsDigit)
            If Char.IsLetter(chr) Then
                If sb.Length > 0 Then list.Add(sb.ToString())
                sb = New System.Text.StringBuilder()
            End If
            sb.Append(chr)
        Next
        If sb.Length > 0 Then list.Add(sb.ToString())
        Return list.ToArray()
    End Function
