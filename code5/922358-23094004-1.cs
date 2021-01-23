    public static void ExportToExcel(DataTable table, string fileName)
    {
    	HttpContext context = HttpContext.Current;
    	context.Response.Clear();
    	context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
    	context.Response.Charset = "windows-1254"; //ISO-8859-13 ISO-8859-9  windows-1254
    	//Begin Table
    	context.Response.Write("<table><tr>");
    
    	//Write Header
    	foreach (DataColumn column in table.Columns)
    	{
    		context.Response.Write("<th>" + column.ColumnName + "</th>");
    	}
    	context.Response.Write("</tr>");
    
    	//Write Data
    	foreach (DataRow row in table.Rows)
    	{
    		context.Response.Write("<tr>");
    		for (int i = 0; i < table.Columns.Count; i++)
    		{
    			context.Response.Write("<td>" + row[i].ToString().Replace(",", string.Empty) + "</td>");
    		}
    		context.Response.Write("</tr>");
    	}
    
    	//End Table
    	context.Response.Write("</table>");
    	context.Response.ContentType = "application/vnd.ms-excel";
    	context.Response.AppendHeader("content-disposition", string.Format("attachment;filename={0}.xls", fileName));
    	context.Response.Flush();
    	context.Response.End();
    }
