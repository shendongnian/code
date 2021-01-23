    private async Task<string> ReadFileAsync()
    {
      var fileStream = File.OpenRead("..\\..\\..\\test.txt"); 
      var buffer = new byte[1024];
    
      await Task<int>.Factory.FromAsync(fileStream.BeginRead, fileStream.EndRead, buffer, 0, buffer.Length, null);
      
      return System.Text.Encoding.ASCII.GetString(buffer);
    }
