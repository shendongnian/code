    protected void btnShowGentle_Click(object sender, EventArgs e)
    {
        ListBoxShow.Items.Clear();
        for (int i = 0; i < personArrayList.Count; i++)
        {
            if(personArrayList[i].gender == "Male")
                ListBoxShow.Items.Add(personArrayList[i].ToString());
        }
    }
    
    ////Possible alternate
    //ListBoxShow.Items.Clear();
    //ListBoxShow.Items.AddRange(personArrayList.Where( x => x.gender == "Male"));
