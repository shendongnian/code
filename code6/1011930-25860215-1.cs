	System.IO.FileStream fos = new System.IO.FileStream(sZipToDirectory + sZipFileName, FileMode.Create);
	Java.Util.Zip.ZipOutputStream zos = new Java.Util.Zip.ZipOutputStream(fos);
	byte[] buffer = new byte[1024];
	for (int i = 0; i < arrFiles.Length; i++) {
		FileInfo fi = new FileInfo (arrFiles[i]);
		Java.IO.FileInputStream fis = new Java.IO.FileInputStream(fi.FullName);
		ZipEntry entry = new ZipEntry(arrFiles[i].Substring(arrFiles[i].LastIndexOf("/") + 1));
		zos.PutNextEntry(entry);
		int count = 0;
		while ((count = fis.Read(buffer)) > 0) {
			zos.Write(buffer, 0, count);
		}
		fis.Close();
		zos.CloseEntry();
	}
