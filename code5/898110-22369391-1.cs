    private OleDbDataReader ExecuteReaderInternal(CommandBehavior behavior, string method)
    {
     OleDbDataReader dataReader = null;
     OleDbException previous = null;
     int num2 = 0;
     try
     {
         object obj2;
         int num;
         this.ValidateConnectionAndTransaction(method);
         if ((CommandBehavior.SingleRow & behavior) != CommandBehavior.Default) behavior |= CommandBehavior.SingleResult;
         switch (this.CommandType)
         {
         case ((CommandType) 0):
         case CommandType.Text:
         case CommandType.StoredProcedure:
             num = this.ExecuteCommand(behavior, out obj2);
             break;
         case CommandType.TableDirect:
             num = this.ExecuteTableDirect(behavior, out obj2);
             break;
         default:
             throw ADP.InvalidCommandType(this.CommandType);
         }
         if (this._executeQuery)
         {
             try
             {
                 dataReader = new OleDbDataReader(this._connection, this, 0, this.commandBehavior);
                 switch (num)
                 {
                 case 0:
                     dataReader.InitializeIMultipleResults(obj2);
                     dataReader.NextResult();
                     break;
                 case 1:
                     dataReader.InitializeIRowset(obj2, ChapterHandle.DB_NULL_HCHAPTER, this._recordsAffected);
                     dataReader.BuildMetaInfo();
                     dataReader.HasRowsRead();
                     break;
                 case 2:
                     dataReader.InitializeIRow(obj2, this._recordsAffected);
                     dataReader.BuildMetaInfo();
                     break;
                 case 3:
                     if (!this._isPrepared) this.PrepareCommandText(2);
                     OleDbDataReader.GenerateSchemaTable(dataReader, this._icommandText, behavior);
                     break;
                 }
                 obj2 = null;
                 this._hasDataReader = true;
                 this._connection.AddWeakReference(dataReader, 2);
                 num2 = 1;
                 return dataReader;
             }
             finally
             {
                 if (1 != num2)
                 {
                     this.canceling = true;
                     if (dataReader != null)
                     {
                         dataReader.Dispose();
                         dataReader = null;
                     }
                 }
             }
         }
         try
         {
             if (num == 0)
             {
                 UnsafeNativeMethods.IMultipleResults imultipleResults = (UnsafeNativeMethods.IMultipleResults) obj2;
                 previous = OleDbDataReader.NextResults(imultipleResults, this._connection, this, out this._recordsAffected);
             }
         }
         finally
         {
             try
             {
                 if (obj2 != null)
                 {
                     Marshal.ReleaseComObject(obj2);
                     obj2 = null;
                 }
                 this.CloseFromDataReader(this.ParameterBindings);
             }
             catch (Exception exception3)
             {
                 if (!ADP.IsCatchableExceptionType(exception3)) throw;
                 if (previous == null) throw;
                 previous = new OleDbException(previous, exception3);
             }
         }
     }
     finally
     {
         try
         {
             if (dataReader == null && 1 != num2) this.ParameterCleanup();
         }
         catch (Exception exception2)
         {
             if (!ADP.IsCatchableExceptionType(exception2)) throw;
             if (previous == null) throw;
             previous = new OleDbException(previous, exception2);
         }
         if (previous != null) throw previous;
     }
     return dataReader;
    }
 
 
