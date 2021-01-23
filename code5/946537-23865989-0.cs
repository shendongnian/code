        List<double> nums = new List<double>();
            for (int i = 0; i < grvData.Rows.Count; i++)
            {
                if (grvData.Rows[i].Cells[23].Text == "OPEN" && grvData.Rows[i].Cells[28].Text == "NO")
                {
                    nums.Add(Convert.ToDouble(grvData.Rows[i].Cells[18].Text));
                }
            }
            nums = nums.OrderByDescending(n => n).ToList();
            NONSPR4.Text = nums[0].ToString();
            NONSPR8.Text = nums[1].ToString();
            NONSPR12.Text = nums[2].ToString();
            NONSPR16.Text = nums[3].ToString();
            NONSPR20.Text = nums[4].ToString();
            NONSPR24.Text = nums[5].ToString();
            NONSPR28.Text = nums[6].ToString();
            NONSPR32.Text = nums[7].ToString();
            NONSPR36.Text = nums[8].ToString();
            NONSPR40.Text = nums[9].ToString();          
