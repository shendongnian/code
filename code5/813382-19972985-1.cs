    'Suppose you have 2 columns , A - a Memo one, B a DateTime one:
    dim SIRCON as string = "your connection string"
    Using conn As New OleDbConnection(SIRCON)
      conn.Open()
      Try
      Using cmd As New OleDbCommand("INSERT INTO MYTABLE (A, B)  VALUES (?,  ?)", conn)
        cmd.Parameters.AddWithValue("P_A", textEdit12.Text.ToString())
        cmd.Parameters.AddWithValue("P_B", DateEdit1.EditValue)
               
        cmd.ExecuteNonQuery()
      End Using
    Finally
     conn.Close()
    End Try
