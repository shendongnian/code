    try
    {
        using(FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
        using(GZipStream gz = new GZipStream(fs, CompressionMode.Compress))
        using(BinaryWriter binaryWriter = new BinaryWriter(gz))
        {
            foreach (double value in bigData)
            {
              binaryWriter.Write(value);
            }
        }
    } catch(System.IO.FileNotFoundException)
    {
        MessageBox.Show("Unexpected save error\n",
        "Save error!", MessageBoxButtons.OK);
    }
