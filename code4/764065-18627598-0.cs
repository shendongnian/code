    Using scope as IDbTransaction = mySqlConnection.BeginTransaction
       If blnEverythingGoesWell Then
          scope.Commit()
       Else
          scope.Rollback()
       End If
    End Using
