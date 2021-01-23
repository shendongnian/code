	MemoryStream ms = new MemoryStream();
	foreach (var file in filesToInclude)
	{
		try
		{
			PdfReader ps = new PdfReader(file);
			PdfStamper pdf = new PdfStamper(ps, ms);//2
			pdf.Close();//4
			HttpContext.Current.Response.ClearContent();//5
			HttpContext.Current.Response.ClearHeaders();//6
			HttpContext.Current.Response.ContentType = "application/pdf";//7
			HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Session["Form_Name"]);//8
			HttpContext.Current.Response.BinaryWrite(ms.ToArray());//9
			ms.Flush();
		}
		catch (Exception ex)
		{
			HandleException(); // Write code to handle exception 
		}
		finally
		{
			 clearcontrols();
		}
	}
