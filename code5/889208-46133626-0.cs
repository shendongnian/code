    using (var s = await file1.OpenStreamForWriteAsync())
    {
        // Add this line
        s.SetLength(0);
        // Then write new bytes. use 's.SetLength(fileBytes.Length)' if needed.
        byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(Convert.ToString(Total));
        s.Write(fileBytes, 0, fileBytes.Length);
    }
