    public string GetSelectedItems(ListBox control)
        {
            var items = new StringBuilder();
            foreach (ListItem item in control.Items)
            {
                if (item.Selected)
                    items.Append(string.Format("{0},", item.Value));
            }
            return items.ToString().Trim().TrimEnd(',');
        }
        protected void btnMoveRight_Click(object sender, EventArgs e)
        {
            for (int i = lbCourses1.Items.Count - 1; i >= 0; i--)
            {
                if (lbCourses1.Items[i].Selected == true)
                {
                    lbCourses2.Items.Add(lbCourses1.Items[i]);
                    ListItem li = lbCourses1.Items[i];
                    lbCourses1.Items.Remove(li);
                }
            }
        }
        protected void btnMoveLeft_Click(object sender, EventArgs e)
        {
            for (int i = lbCourses2.Items.Count - 1; i >= 0; i--)
            {
                if (lbCourses2.Items[i].Selected == true)
                {
                    lbCourses1.Items.Add(lbCourses2.Items[i]);
                    ListItem li = lbCourses2.Items[i];
                    lbCourses2.Items.Remove(li);
                }
            }
        }
		
		var selectedValues =  GetSelectedItems(lb2);
