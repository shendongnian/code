    public static byte[] Serialize(this ITableEntity entity)
    {
    MemoryStream ms = new MemoryStream();
    using(var messageWriter = new ODataMessageWriter(new Message(ms), new ODataMessageWriterSettings()))
    {
        // Create an entry writer to write a top-level entry to the message.
        ODataWriter entryWriter = messageWriter.CreateODataEntryWriter();
        var writeODataEntity =typeof(TableConstants).Assembly.GetType("Microsoft.WindowsAzure.Storage.Table.Protocol.TableOperationHttpWebRequestFactory")
            .GetMethod("WriteOdataEntity", BindingFlags.NonPublic | BindingFlags.Static);
        writeODataEntity.Invoke(null, new object[] { entity, TableOperationType.Insert, null, entryWriter });
        return ms.ToArray();
    }            
    }
    public static void Deserialize(this ITableEntity entity, byte[] value)
    {
    MemoryStream ms = new MemoryStream(value);
    using(ODataMessageReader messageReader = new ODataMessageReader(new Message(ms), new ODataMessageReaderSettings()))
    {
        ODataReader reader = messageReader.CreateODataEntryReader();
        var readAndUpdateTableEntity = typeof(TableConstants).Assembly.GetType("Microsoft.WindowsAzure.Storage.Table.Protocol.TableOperationHttpResponseParsers")
            .GetMethod("ReadAndUpdateTableEntity", BindingFlags.NonPublic | BindingFlags.Static);
        reader.Read();
        readAndUpdateTableEntity.Invoke(null, new object[] { entity,  reader.Item, 31, null });
    }
    }
    internal class Message : IODataResponseMessage
    {
    private readonly Stream stream;
    private readonly Dictionary<string, string> headers = new Dictionary<string, string>();
    public Message(Stream stream)
    {
        this.stream = stream;
        SetHeader("Content-Type", "application/atom+xml");
    }
    public string GetHeader(string headerName)
    {
        string value;
        headers.TryGetValue(headerName, out value);
        return value;
    }
    public void SetHeader(string headerName, string headerValue)
    {
        this.headers.Add(headerName, headerValue);
    }
    public Stream GetStream()
    {
        return this.stream;
    }
    public IEnumerable<KeyValuePair<string, string>> Headers
    {
        get
        {
            return this.headers;
        }
    }
    public int StatusCode
    {
        get;
        set;
    }
    }
