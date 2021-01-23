	public void DownloadExcel(byte[] buffer, string nameFile) {
		// Verify invalid chars on nameArchive parameter:
		var preparedName = new String(
		   nameFile.Where(c => !Path.GetInvalidFileNameChars().Contains(c)).ToArray()
		);
		if (String.IsNullOrEmpty(preparedName))
		   preparedName = "DefaultName";
		HttpResponse response = HttpContext.Current.Response;
		response.Clear();
		response.ContentType = 
		   "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
		response.AddHeader("Content-Disposition", 
		   String.Format("attachment;filename={0}.xlsx", preparedName));
		response.AddHeader("Content-Length", buffer.Length.ToString());
		response.BinaryWrite(buffer);
		response.End();
	}
