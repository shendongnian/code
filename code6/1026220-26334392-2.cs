    ...
    process.Start();
    Task.Factory.StartNew(new Action<object>(ReadFromStreamReader), process.StandardOutput);
    void ReadFromStreamReader(object state)
    {
        StreamReader reader = state as StreamReader;
        char[] buffer = new char[1024];
        int chars;
        while ((chars = reader.Read(buffer, 0, buffer.Length)) > 0)
        {
            string data = new string(buffer, 0, chars);
            OnDataReceived(data);
        }
        // You arrive here when process is terminated.
    }
    void OnDataReceived(string data)
    {
        // Process the data here. It might contain only a chunk of a full line
        // remember to use Invoke() if you want to update something in your form GUI
    }
