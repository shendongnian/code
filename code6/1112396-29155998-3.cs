    using (httpWebResponse)
    {
        ...
        using (var file = new FileStream("some\path\to\file.json",FileMode.Create,FileAccess.Write,FileShare.None))
        {
            StreamWriter writer = new StreamWriter(file,Encoding.UTF8);
            writer.Write(response_body);
            writer.Flush();
        }
    }
