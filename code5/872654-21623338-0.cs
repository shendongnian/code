    protected void Page_Load(object sender, EventArgs e)
        {
            lstboxSkill.Items.Add("ASP.Net");
            lstboxSkill.Items.Add("C#");
            lstboxSkill.Items.Add("AJAX");
            lstboxSkill.Items.Add("JavaScript");
            lstboxSkill.Items.Add("HTML");
            lstboxSkill.Items.Add("HTML5");
            lstboxSkill.Items.Add("JQuery");
        }
    protected void imgbtnMoveRightListBox_Click(object sender, EventArgs e)
        {
            foreach (ListItem Item in lstboxSkill.Items)
            {
                if (Item.Selected == true)
                {
                    lstBBoxSkill2.Items.Add(Item);
                }
            }            
        }
