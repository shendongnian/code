    {
        ...
        var fs = new FileStream(...); // using FileStream as an example
        var data = new byte[100];
        var ar = fs.BeginRead(data, 0, 100, MyCallback, new object[] { fs, data });
        ...
        // you can check the IAsyncResult ar for completion,
        // or do some work that doesn't depend on the data
    }
    private void MyCallback(IAsyncResult ar)
    {
        // AsyncState gets the last parameter from the call to BeginRead
        var fs = (FileStream)(((object[])ar.AsyncState)[0]);
        var data = (FileStream)(((object[])ar.AsyncState)[1]);
        int numberOfBytesRead = fs.EndRead(ar);
        // do something with data
    }
