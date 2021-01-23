    public void color_check()  //this is my problem making fn
    {
        dataGridView1.Refresh();
        string strVal = ini.ReadValue("Action", "Doc-Controller");
        bool authenticated = true;
        if (authenticated == UserInCustomRole(strVal))
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
               Dispatcher.BeginInvoke(DispatcherPriority.Background, ()=>{Process(row);});
            }
        }
    }
