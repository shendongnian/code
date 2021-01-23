    using (ShimsContext.Create())
    {
        ShimDirectory.CreateDirectoryString = path =>
        {
          // Your fake code here
        }
        _path = @"\\" + TestConfig.Instance.FileShareHost + @"\SharingIsGood";
        Directory.CreateDirectory(_path);
    }
