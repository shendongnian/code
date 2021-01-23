    private void UpdateComponents(string[] request)
    {
        foreach (string r in request)
        {
            if (r == "ListViewSubnetworksChanged")
            {
                if (listView1.InvokeRequired)
                {
                    this.Invoke(new Action(() => listView1.Items.Clear()));
                }
                else
                {
                    listView1.Items.Clear();
                }
                return;
            }
        }
    }
