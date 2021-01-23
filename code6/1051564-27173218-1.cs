    Try
        db_connection()
        mySqlDataAdapter.Update(DS.Tables(0))
    Catch ex As Exception
        MsgBox(ex.Message(), MsgBoxStyle.Critical)
        If Not IsNothing(ex.InnerException) Then MsgBox(ex.InnerException.Message, MsgBoxStyle.Critical)
    End Try
