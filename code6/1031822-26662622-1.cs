    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using Microsoft.SqlServer.Server;
    
    private static IEnumerable<SqlDataRecord> SendRows(List<CellModel> Cells)
    {
       SqlMetaData[] _TvpSchema = new SqlMetaData[] {
          new SqlMetaData("ScheduleTaskID", SqlDbType.Int),
          new SqlMetaData("IsCompleted", SqlDbType.Bit),
          new SqlMetaData("ActualStart", SqlDbType.DateTime),
          new SqlMetaData("ActualFinish", SqlDbType.DateTime),
          new SqlMetaData("ActualEndDate", SqlDbType.DateTime),
          new SqlMetaData("UserDate1", SqlDbType.DateTime)
       };
    
       SqlDataRecord _DataRecord = new SqlDataRecord(_TvpSchema);
    
       // read a row, send a row
       for (int _Index = 0; _Index < Cells.Count; _Index++)
       {
          // Unlike BCP and BULK INSERT, you have the option here to create an
          // object, do manipulation(s) / validation(s) on the object, then pass
          // the object to the DB or discard via "continue" if invalid.
          _DataRecord.SetInt32(0, Cells[_Index].scheduleTaskID);
          _DataRecord.SetBoolean(1, Cells[_Index].selected); // IsCompleted
          _DataRecord.SetDatetime(2, Cells[_Index].actualDate); // ActualStart
          _DataRecord.SetDatetime(3, Cells[_Index].finishedDate); // ActualFinish
          _DataRecord.SetDatetime(4, Cells[_Index].finishedDate); // ActualEndDate
          _DataRecord.SetDatetime(5, Cells[_Index].scheduledDate); // UserDate1
    
          yield return _DataRecord;
       }
    }
