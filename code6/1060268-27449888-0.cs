    void SomeMethod()
    {
        Process process = ...; // init as appropriate, including redirection of stdout
        StringBuilder sb = new StringBuilder();
        var _ = ConsumeReader(process.StandardOutput, sb);
    }
    async Task ConsumeReader(TextReader reader, StringBuilder sb)
    {
        char[] buffer = new char[1024];
        int cch;
        while ((cch = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            sb.Append(buffer, 0, cch);
        }
    }
