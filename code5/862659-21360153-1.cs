        delegate ListView.ListViewItemCollection DelGetItems(ListView lvControl);
        ListView.ListViewItemCollection GetItems(ListView lvControl)
        {
            if (lvControl.InvokeRequired)
            {
                return (ListView.ListViewItemCollection)lvControl.Invoke(new DelGetItems(GetItems) ,new Object[] { lvControl });
            }
            else
            {
                return lvControl.Items;
            }
        }
