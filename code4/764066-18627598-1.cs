    Using scope as IDbTransaction = mySqlCommand.Connection.BeginTransaction()
       If blnEverythingGoesWell Then
          scope.Commit()
       Else
          scope.Rollback()
       End If
    End Using
