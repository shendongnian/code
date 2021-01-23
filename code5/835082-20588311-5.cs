    protected void Button5_Click(object sender, EventArgs e)
    {
            ListItem item = null;
            for(var i=0;i<lb2.Items.Count;i++)
            {
                item = lb2.Items[i];
                if (item.Selected)
                {
                    var e1 = new employee() { emp_skill = item.Text };
                    je.employee.AddObject(e1);
                }
            }
            je.SaveChanges();
    }
