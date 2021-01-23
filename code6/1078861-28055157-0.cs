    string xml = @"
      <SyncTable>
        <SyncEntry>
          <Cal_ID>1234</Cal_ID>
          <Cal_LastUpdated>2015-01-20T14:25:34.828-05:00</Cal_LastUpdated>
          <Cal_StartDateTime>2015-01-22T20:05:00-05:00</Cal_StartDateTime>
        </SyncEntry>
        <SyncEntry>
          <Cal_ID>4567</Cal_ID>
          <Cal_LastUpdated>2015-01-20T11:00:24.988-05:00</Cal_LastUpdated>
          <Cal_StartDateTime>2015-02-10T18:30:00-05:00</Cal_StartDateTime>
        </SyncEntry>
      </SyncTable>
      ";
      
      XmlDocument doc = new XmlDocument() ;
      doc.LoadXml( xml ) ;
      
      DateTime       dtNow = DateTime.UtcNow ;
      DateTimeStyles style = DateTimeStyles.AssumeUniversal
                           | DateTimeStyles.AdjustToUniversal
                           | DateTimeStyles.AllowWhiteSpaces
                           ;
      foreach( XmlNode node in doc.SelectNodes( "/SyncTable/SyncEntry/Cal_StartDateTime" ) )
      {
        DateTime startDate ;
        bool isValid = DateTime.TryParseExact( node.InnerText , "yyyy-MM-ddTHH:mm:ssK" , CultureInfo.InvariantCulture , style , out startDate ) ;
        if ( !isValid || startDate < dtNow )
        {
          doc.DocumentElement.RemoveChild(node.ParentNode);
        }
      }
      
