    class Program
    {
        static void Main(string[] args)
        {
            var xmlString = @"<SyncTables>
    <SyncTable>
      <SyncEntry>
        <Cal_ID>1234</Cal_ID>
        <Cal_LastUpdated>2015-01-20T14:25:34.828-05:00</Cal_LastUpdated>
        <Cal_StartDateTime>2015-01-22T20:05:00-05:00</Cal_StartDateTime>
      </SyncEntry>
      <SyncEntry>
        <Cal_ID>4567</Cal_ID>
        <Cal_LastUpdated>2015-01-10T11:00:24.988-05:00</Cal_LastUpdated>
        <Cal_StartDateTime>2015-02-10T18:30:00-05:00</Cal_StartDateTime>
      </SyncEntry>
    </SyncTable>
    </SyncTables>";
            var xml = XElement.Parse(xmlString);
            var syncTablesToRemove =
                xml.Elements("SyncTable")
                    .Where(x =>
                        x.Descendants("Cal_StartDateTime")
                            .Select(y => DateTime.Parse(y.Value)).Max() < DateTime.Now.Date);
            foreach (var syncEntry in syncTablesToRemove)
            {
                syncEntry.Remove();
            }
            Console.WriteLine(xml);
            Console.ReadLine();
        }
    }
