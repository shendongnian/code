	protected void btnExportCSV_Click(object sender, EventArgs e)
	{
		Response.Clear();
		Response.Buffer = true;
		Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.csv");
		Response.Charset = "";
		Response.ContentType = "application/text";
		GridView1.AllowPaging = false;
		GridView1.DataBind();
		StringBuilder sb = new StringBuilder();
		bool hitFirstStartTime = false;
		for (int k = 0; k < GridView1.Columns.Count; k++)
		{
			var letsDoThis = false;
			if (GridView1.Columns[k].HeaderText == "Storeid" ||
				GridView1.Columns[k].HeaderText == "Date" ||
				GridView1.Columns[k].HeaderText == "EmpID")
			{
				letsDoThis = true;
			}
			else if (GridView1.Columns[k].HeaderText == "Starttime" && !hitFirstStartTime)
			{
				letsDoThis = true;
				hitFirstStartTime = true;
			}
			else if (GridView1.Columns[k].HeaderText == "Endtime" &&  k == GridView1.Columns.Count)
			{
				letsDoThis = true;
			}
			if (letsDoThis)
				sb.Append(GridView1.Columns[k].HeaderText + ',');
		}
		//append new line
		sb.Append("\r\n");
		for (int i = 0; i < GridView1.Rows.Count; i++)
		{
			bool hitFirstStartTime = false;
			for (int k = 0; k < GridView1.Columns.Count; k++)
			{
				var letsDoThis = false;
				if (GridView1.Columns[k].HeaderText == "Storeid" ||
					GridView1.Columns[k].HeaderText == "Date" ||
					GridView1.Columns[k].HeaderText == "EmpID")
					letsDoThis = true;
				else if (GridView1.Columns[k].HeaderText == "Starttime" && 
						 !hitFirstStartTime)
					letsDoThis = true;
				else if (GridView1.Columns[k].HeaderText == "Endtime" && 
						 k == GridView1.Columns.Count)
					letsDoThis = true;
				{
					letsDoThis = true;
					hitFirstStartTime = true;
				}
				if (letsDoThis)
					sb.Append(GridView1.Columns[k].HeaderText + ',');
			}
			//append new line
			sb.Append("\r\n");
		}
		Response.Output.Write(sb.ToString());
		Response.Flush();
		Response.End();
	}
