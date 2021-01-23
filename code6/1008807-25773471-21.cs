    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using Microsoft.SqlServer.Server;
    private static IEnumerable<SqlDataRecord> GetFileContents()
    {
       SqlMetaData[] _TvpSchema = new SqlMetaData[] {
          new SqlMetaData("Field", SqlDbType.VarChar, SqlMetaData.Max)
       };
       SqlDataRecord _DataRecord = new SqlDataRecord(_TvpSchema);
       StreamReader _FileReader = null;
    
       try
       {
          _FileReader = new StreamReader("{filePath}");
    
          // read a row, send a row
          while (!_FileReader.EndOfStream)
          {
             // You shouldn't need to call "_DataRecord = new SqlDataRecord" as
             // SQL Server already received the row when "yield return" was called.
             // Unlike BCP and BULK INSERT, you have the option here to create a string
             // call ReadLine() into the string, do manipulation(s) / validation(s) on
             // the string, then pass that string into SetString() or discard if invalid.
             _DataRecord.SetString(0, _FileReader.ReadLine());
             yield return _DataRecord;
          }
       }
       finally
       {
          _FileReader.Close();
       }
    }
