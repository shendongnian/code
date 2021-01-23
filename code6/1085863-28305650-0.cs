	Private Shared Function UrlEncode(ByVal url As String) As String
		Dim encoded As New StringBuilder(url.Length * 2)
		Dim unreservedChars As String = String.Concat(ValidUrlCharacters, ValidPathCharacters)
		For Each symbol As Char In System.Text.Encoding.UTF8.GetBytes(url)
			If unreservedChars.IndexOf(symbol) <> -1 Then
				encoded.Append(symbol)
			Else
				encoded.Append("%").Append(String.Format(CultureInfo.InvariantCulture, "{0:X2}", AscW(symbol)))
			End If
		Next symbol
		Return encoded.ToString()
	End Function
