    // sqlcmd.exe
    // -S .\PDATA_SQLEXPRESS
    // -U sa
    // -P 2BeChanged!
    // -d PDATA_SQLEXPRESS
    // -s ; -W -w 100
    // -Q "SELECT tPatCulIntPatIDPk, tPatSFirstname, tPatSName, tPatDBirthday  FROM  [dbo].[TPatientRaw] WHERE tPatSName = '%name%' "
    
    DataTable dt            = new DataTable() ;
    int       rows_returned ;
    
    const string credentials = @"Server=(localdb)\.\PDATA_SQLEXPRESS;Database=PDATA_SQLEXPRESS;User ID=sa;Password=2BeChanged!;" ;
    const string sqlQuery = @"
      select tPatCulIntPatIDPk ,
             tPatSFirstname    ,
             tPatSName         ,
             tPatDBirthday
      from dbo.TPatientRaw
      where tPatSName = @patientSurname
      " ;
    
    using ( SqlConnection connection = new SqlConnection(credentials) )
    using ( SqlCommand    cmd        = connection.CreateCommand() )
    using ( SqlDataAdapter sda       = new SqlDataAdapter( cmd ) )
    {
      cmd.CommandText = sqlQuery ;
      cmd.CommandType = CommandType.Text ;
      connection.Open() ;
      rows_returned = sda.Fill(dt) ;
      connection.Close() ;
    }
    
    if ( dt.Rows.Count == 0 )
    {
      // query returned no rows
    }
    else
    {
      
      //write semicolon-delimited header
      string[] columnNames = dt.Columns
                               .Cast<DataColumn>()
                               .Select( c => c.ColumnName )
                               .ToArray()
                               ;
      string   header      = string.Join("," , columnNames) ;
      Console.WriteLine(header) ;
      
      // write each row
      foreach ( DataRow dr in dt.Rows )
      {
        
        // get each rows columns as a string (casting null into the nil (empty) string
        string[] values = new string[dt.Columns.Count];
        for ( int i = 0 ; i < dt.Columns.Count ; ++i )
        {
          values[i] = ((string) dr[i]) ?? "" ; // we'll treat nulls as the nil string for the nonce
        }
        
        // construct the string to be dumped, quoting each value and doubling any embedded quotes.
        string data = string.Join( ";" , values.Select( s => "\""+s.Replace("\"","\"\"")+"\"") ) ;
        Console.WriteLine(values);
        
      }
      
    }
