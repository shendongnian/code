    for (int i = 0; i < dTable.Rows.Count; i++)
	{
	   string strRowNum = dTable.Rows[i][8].ToString(); // RowNum
	   string strStarCtn = dTable.Rows[i][6].ToString();  // starCtn
	   int temp = 0;
	   int starCount;
	   int numRows;
	   bool result1 = int.TryParse(strRowNum, out numRows);
	   bool result2 = int.TryParse(strStarCtn, out starCount);
	   if (result1 && result2)
	   {
		   if (last_starCtn == starCount)
		   {
			   tie_counter++;
			   temp = numRows - tie_counter;
			   dTable.Rows[i][8] = temp.ToString();  // RowNum
		   }
		   else
		   {
			   tie_counter = 0;
			   last_starCtn = starCount;
		   }
	   }
	}
	rpt_BoardList.DataSource = dTable;
	rpt_BoardList.DataBind();
