            protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList lstBx = (CheckBoxList)sender;
            List<ListItem> list = lstBx.Items.Cast<ListItem>().ToList();
            string[] control = Request.Form.Get("__EVENTTARGET").Split('$');
            int index = Convert.ToInt32(control[control.Length - 1]);
            ListItem selectAllControl = list.FirstOrDefault(x => x.Text == "Select All");
            ListItem selectAll = list.FirstOrDefault(x => x.Selected && x.Text == "Select All");
            if (index == 0)
            {               
                if (selectAll != null)
                {
                    foreach (var item in list)
                    {
                        item.Selected = true;
                    }
                }
            }
            else
            {
                if (selectAllControl != null)
                {
                    selectAllControl.Selected = false;
                }
            }
        }
