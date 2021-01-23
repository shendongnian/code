    protected void RowUpdatingHandler(RowUpdatingEventArgs rowUpdatingEvent)
    {
      if (rowUpdatingEvent == null)
        throw ADP.ArgumentNull("rowUpdatingEvent");
      try
      {
        if (rowUpdatingEvent.Status != UpdateStatus.Continue)
          return;
        StatementType statementType = rowUpdatingEvent.StatementType;
        DbCommand dbCommand1 = (DbCommand) rowUpdatingEvent.Command;
        if (dbCommand1 != null)
        {
          DbCommand dbCommand2;
          switch (statementType)
          {
            case StatementType.Select:
              return;
            case StatementType.Insert:
              dbCommand2 = this.InsertCommand;
              break;
            case StatementType.Update:
              dbCommand2 = this.UpdateCommand;
              break;
            case StatementType.Delete:
              dbCommand2 = this.DeleteCommand;
              break;
            default:
              throw ADP.InvalidStatementType(statementType);
          }
          if (dbCommand2 != rowUpdatingEvent.Command)
          {
            dbCommand1 = (DbCommand) rowUpdatingEvent.Command;
            if (dbCommand1 != null && dbCommand1.Connection == null)
            {
              DbDataAdapter dataAdapter = this.DataAdapter;
              DbCommand dbCommand3 = dataAdapter != null ? dataAdapter.SelectCommand : (DbCommand) null;
              if (dbCommand3 != null)
                dbCommand1.Connection = dbCommand3.Connection;
            }
          }
          else
            dbCommand1 = (DbCommand) null;
        }
        if (dbCommand1 != null)
          return;
        this.RowUpdatingHandlerBuilder(rowUpdatingEvent);
      }
      catch (Exception ex)
      {
        if (!ADP.IsCatchableExceptionType(ex))
        {
          throw;
        }
        else
        {
          ADP.TraceExceptionForCapture(ex);
          rowUpdatingEvent.Status = UpdateStatus.ErrorsOccurred;
          rowUpdatingEvent.Errors = ex;
        }
      }
    }
