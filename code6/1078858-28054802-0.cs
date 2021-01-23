    class Program
    {
        static void Main(string[] args)
        {
            var xmlString = @"<SyncTable>
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
    </SyncTable>";
            var xml = XElement.Parse(xmlString);
            var syncEntriesToRemove =
                xml.Elements("SyncEntry")
                    .Where(x => DateTime.Parse(x.Element("Cal_StartDateTime").Value)
                       < DateTime.Now);
            foreach (var syncEntry in syncEntriesToRemove)
            {
                syncEntry.Remove();
            }
            Console.WriteLine(xml);
            Console.ReadLine();
        }
    }
