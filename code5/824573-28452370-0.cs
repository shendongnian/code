    private void ProcessWithSharpZipLib()
{
    byte[] buffer = new byte[4096];
    ICSharpCode.SharpZipLib.Zip.ZipOutputStream zipOutputStream = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(Response.OutputStream);
    zipOutputStream.SetLevel(0); //0-9, 9 being the highest level of compression
    zipOutputStream.UseZip64 = ICSharpCode.SharpZipLib.Zip.UseZip64.Off;
    foreach (KeyValuePair<string, string> fileNamePair in urls)
    {
        using (WebClient wc = new WebClient())
        {
            using (Stream wcStream = wc.OpenRead(GetUrlForEntryName(fileNamePair.Key)))
            {
                ICSharpCode.SharpZipLib.Zip.ZipEntry entry = new ICSharpCode.SharpZipLib.Zip.ZipEntry(ICSharpCode.SharpZipLib.Zip.ZipEntry.CleanName(fileNamePair.Key));
                zipOutputStream.PutNextEntry(entry);
                int count = wcStream.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    zipOutputStream.Write(buffer, 0, count);
                    count = wcStream.Read(buffer, 0, buffer.Length);
                    if (!Response.IsClientConnected)
                    {
                        break;
                    }
                    Response.Flush();
                }
            }
        }
    }
    zipOutputStream.Close();
    Response.Flush();
    Response.End();`enter code here`
