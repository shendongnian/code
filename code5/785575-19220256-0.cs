    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData1();
            switch (this.tabControl1.SelectedTab.Name)
            {
                case "tpUpdate":
                     listViewClients.Items[0].Selected = true;
                     listViewClients.Select();
                      break;
                      case "tpDelete":
                      listView1.Items[0].Selected = true;
                listView1.Select();
                   break;                     
            }                      
        }
