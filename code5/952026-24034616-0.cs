    // showing form2 and pass the value of the _handle
    private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listView1.SelectedItems)
        {
            int _handle = (int)item.Tag;
            sf = new SendForm(_handle, this);
            sf.Show();
        } 
    }
    // sending message using socket
    public void sendT(int _handle, string msg)
    {
        byte[] sdata = Encoding.ASCII.GetBytes(msg);
        serverSocket[_handle].Send(sdata, 0, sdata.Length, 0);
    }
