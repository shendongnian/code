    public async static Task<IInputStream> ToInputStreamAsync(this string input)
    {
        var ms = new InMemoryRandomAccessStream();
        using(var dw = new DataWriter(ms))
        {
            dw.WriteString(input);
            await dw.StoreAsync();
            dw.DetachStream();
        }
        return ms;
    }
