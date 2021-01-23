        foreach (DataRow row in dtTemp.Rows)
        {
            ListItem lstim = new ListItem();
            lstim.Text = row["ExamleColumnName1"].ToString();
           
            if (lstSelectedWorkout.Items.Contains(lstim) == true)
            {
                // Response.Write("<script>alert('" +  lstMajorMuscles.SelectedItem.Text + " already exist in the list')</script>");
            }
            else
            {
                lstSelectedWorkout.Items.Add(row["ExamleColumnName1"].ToString());
            }
        }
