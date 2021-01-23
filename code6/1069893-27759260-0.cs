    public static byte[] CompressToZip(List<Tuple<byte[], string>> fileItemList, int zipLevel = 3)
        {
            MemoryStream zipMemoryStream = new MemoryStream();
            ZipOutputStream zOutput = new ZipOutputStream(zipMemoryStream);
            zOutput.SetLevel(zipLevel);
            ICSharpCode.SharpZipLib.Checksums.Crc32 crc = new ICSharpCode.SharpZipLib.Checksums.Crc32();
            foreach (var file in fileItemList)
            {
                ZipEntry entry = new ZipEntry(file.Item2);
                entry.DateTime = DateTime.Now;
                zOutput.PutNextEntry(entry);
                var memStreamCurrentfile = new MemoryStream(file.Item1);
                StreamUtils.Copy(memStreamCurrentfile, zOutput, new byte[4096]);
                zOutput.CloseEntry();
            }
            zOutput.IsStreamOwner = false;
            zOutput.Finish();
            zOutput.Close();
            zipMemoryStream.Position = 0;
            byte[] zipedFile = zipMemoryStream.ToArray();
            return zipedFile;
        }
