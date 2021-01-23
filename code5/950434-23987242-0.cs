    private void button1_Click(object sender, EventArgs e)
    {
    jabber.Send("<iq type="get" to="" + textBox1.Text + "@conference.jabber.com" id="qip_1026"><query xmlns="http://jabber.org/protocol/muc#admin"><item affiliation="outcast" /></query></iq>");
    }
 
    private void button2_Click(object sender, EventArgs e)
    {
    progressBar1.Maximum = listBox1.Items.Count;
    progressBar1.Value = 0;
    // Set the timer interval to four seconds
    timer1.Interval = 4000;
    // Start the timer
    timer1.Start();
    }
 
    private void timer1_Tick(object sender, EventArgs e)
     {
    // Disable the timer while we are working in this procedure so
    // it doesn't tick while we are working in this procedure
    timer1.Enabled = False;
    // Send only if there are items in the ListBox
    if (listBox1.Items.Count > 0)
    {
        jabber.Send("<iq type="set" to="" + textBox7.Text + "@conference.jabber.com"><query xmlns="http://jabber.org/protocol/muc#admin"><item jid="" + listBox1.Items[0].ToString() + "" affiliation="none" /></query></iq>");
        listBox1.Items.RemoveAt(0);
        progressBar1.Value += 1;
        label.Text = listBox1.Items.Count.ToString();
    }
    // Re-enable only if there are items left in the ListBox
    if (listBox1.Items.Count > 0)
    {
         timer1.Enabled = True;
    }
     }
