        Dim theProblemWithTheData As String = String.Format("$-123.45{0}", vbCrLf)
    Dim dontDoThis As New System.Data.SqlClient.SqlParameter("fakeParameter",
                                                             SqlDbType.Decimal)
    Dim doThis As New System.Data.SqlClient.SqlParameter("betterFakeParameter",
                                                         SqlDbType.Decimal)
    Dim doThisValue As Decimal
    Try
      dontDoThis.Value = theProblemWithTheData
      Dim success As Boolean = Decimal.TryParse(theProblemWithTheData,
                                                System.Globalization.NumberStyles.Any,
                                                System.Globalization.CultureInfo.CurrentCulture,
                                                doThisValue)
      If success Then
        doThis.Value = doThisValue
      End If
    Catch ex As Exception
      Dim exInfo As String = ex.ToString
    End Try
