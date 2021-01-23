    tempWorkSheet.Range[tempWorkSheet.Cells[1, 1], tempWorkSheet.Cells[3, 3]].CopyPicture(Excel.XlPictureAppearance.xlScreen, Excel.XlCopyPictureFormat.xlBitmap);
    
    var data = System.Windows.Forms.Clipboard.GetDataObject();
    
    using (var ms = data.GetData(System.Windows.Forms.DataFormats.Dib) as MemoryStream)
            {
                byte[] buff = new byte[ms.Capacity];
                if (ms.CanRead)
                {
                    ms.Read(buff, 0, ms.Capacity);
                }
                MemoryStream ms2 = new MemoryStream();
      
                byte[] bmpHeader = new byte[] { 0x42, 0x4D, 0x96, 0x86, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x00 };
      
                ms2.Write(bmpHeader, 0, bmpHeader.Length);
                ms2.Write(buff, 0, buff.Length);   
    
                string local_filename = "E:\TEST.png";
    
                File.WriteAllBytes(local_filename, ms2.ToArray());
                ms2.Dispose();
            }    
