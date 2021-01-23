     string s;
     for (int i = 0; i < CheckBoxList1.Items.Count - 1;i++ )
        {
            if(CheckBoxList1.Items[i].Selected)//changed 1 to i 
                s += CheckBoxList1.Items[i].Text.ToString() + ","; //changed 1 to i
        }
     cmd.Parameters.AddWithValue("@qual",s);
