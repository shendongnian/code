    If IsValid Then
        Try
            Dim strSQL = "insert into CreatePatient  (Account, Password, FirstName, LastName, " & _
                     "Address, HomePhone, Mobile, City, State, Zip, Social, Age, Gender, " & _
                     "Height, Weight, Marital, Spouse) values (@Account, @Password, @FirstName, " & _
                     "@LastName, @Address, @HomePhone, @Mobile, @City, @State, @Zip, @Social, " & _
                     "@Age, @Gender, @Height, @Weight, @Marital, @Spouse)"
            Using CCSQL = new SqlConnection(ConfigurationManager.ConnectionStrings("CreatePatientConnectionString").ConnectionString)
            Using CCUser = new SqlCommand(strSQL, CCSQL)
                CCSQL.Open()
                CCUser.Parameters.Add("@Account", Data.SqlDbType.VarChar).Value = Account.Text
                ......
                CCUser.ExecuteNonQuery()
            End Using
            End Using
            Response.Redirect("ProcedureSelectionForm.aspx")
        Catch ex As Exception
            ErrorTXT.Text = ex.Message
        End Try
    End If
