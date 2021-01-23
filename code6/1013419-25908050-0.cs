    public async Task CopyAsync(string sourcePath, string destinationPath)
    {
        using (var source = File.Open(sourcePath, FileMode.Open))
        {
            using (var destination = File.Create(destinationPath))
            {
                await source.CopyToAsync(destination);
            }
        }
    }
