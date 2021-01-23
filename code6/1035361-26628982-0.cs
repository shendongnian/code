    protected void Button1_Click(object sender, EventArgs e)
    {
            DataTable dt1;
            DataRow row; 
            dt1 = new DataTable();
            dt1.Columns.Add("GroupNo");
            dt1.Columns.Add("Registration");
            dt1.Columns.Add("Name");
            dt1.Columns.Add("Marks");
            dt1.Columns.Add("Technology");
            dt1.AcceptChanges();
            return dt1;
            
            int starting = 0, Ending = GridView1.Rows.Count-1, flag = 0, groupsize =5 , Count_Stu = 1;
    
            for (int i = 0; i <= countvalue; i++)
            {
                if (flag == 0)	// Top To Down
                {
                    row = dt1.NewRow();
                    row["GroupNo"] = Count_Stu.ToString();
                    row["Registration"] = GridView1.Rows[starting].Cells[0].Text;
                    row["Name"] = GridView1.Rows[starting].Cells[1].Text;
                    row["Marks"] = GridView1.Rows[starting].Cells[2].Text;
                    row["Technology"] = GridView1.Rows[starting].Cells[3].Text;
                    dt1.Rows.Add(row);
                    Count_Stu++;
                    starting++;
                }
                else if (flag == 1)	// Down To Up
                {
                    row = dt1.NewRow();
                    row["GroupNo"] = Count_Stu.ToString();
                    row["Registration"] = GridView1.Rows[Ending].Cells[0].Text;
                    row["Name"] = GridView1.Rows[Ending].Cells[1].Text;
                    row["Marks"] = GridView1.Rows[Ending].Cells[2].Text;
                    row["Technology"] = GridView1.Rows[Ending].Cells[3].Text;
                    dt1.Rows.Add(row);
                    Count_Stu++;
                    Ending--;
                }
    
                if (Count_Stu == groupsize+1)	//Reset 
                {
                    if (flag == 0)
                        flag = 1;
                    else
                        flag = 0;
                    Count_Stu = 1;
                }
            }
            GridView2.DataSource = dt1;
            GridView2.DataBind();
    
        }
