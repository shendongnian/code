    private void UpdateComponents(string[] request)
    {
        for (int j = 0; j < request.Length; j++)
        {
            switch (request[j])
            {
                case "ListViewSubnetworksChanged":
                    if (listView1.InvokeRequired)
                    {
                        this.Invoke(new Action(() => listView1.Items.Clear()));
                    }
                    else
                    {
                        listView1.Items.Clear();
                    }
                    break;
            }
        }
    }
