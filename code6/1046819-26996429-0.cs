    public async Task ReadFromFileAsync(string in_filePath, IProgress<cUpdateEventArgs> progress)
    {
      // Do a bit of reading all bytes here and error-checking there...
      //Here comes the heavy lifting
      ReadTriangles(stlBytes.SubArray(cConstants.BYTES_IN_HEADER, stlBytes.Length - cConstants.BYTES_IN_HEADER), progress);
    }
    private void ReadTriangles(byte[] in_triangles, IProgress<cUpdateEventArgs> progress)
    {
      UInt32 numberOfTriangles = BitConverter.ToUInt32(cHelpers.HandleLSBFirst(in_triangles.SubArray(0, 4)), 0);
      float percentage = 0;
      float percentageOld = percentage;
      if (progress != null)
        progress.Report(new cReadUpdateEventArgs(id, Resources.Texts.ReadingTriangles, percentage));
      for (UInt32 i = 0; i < numberOfTriangles; i++)
      {
        percentage = ((float)(i + 1)) / numberOfTriangles * 100;
        triangleList.Add(new cSTLTriangle(in_triangles.SubArray(Convert.ToInt32(i * cConstants.BYTES_PER_TRIANGLE + 4), Convert.ToInt32(cConstants.BYTES_PER_TRIANGLE))));
        if (percentage - percentageOld >= 0.1) //Just tell about .1-percentage increases
        {
          percentageOld = percentage;
          if (progress != null)
            progress.Report(new cReadUpdateEventArgs(id, Resources.Texts.ReadingTriangles, percentage));
        }
      }
      if (progress != null)
        progress.Report(new cReadUpdateEventArgs(id, Resources.Texts.ReadingTriangles, percentage));
    }
