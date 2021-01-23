    private void timer1_Tick(object sender, EventArgs e)
        {
            lock (listBox1)
            {
                if (listBox1.Items.Count > 0)
                {
                    jabber.Send("<iq type='set' to='" + textBox7.Text +
                                "@conference.jabber.com'><query xmlns='http://jabber.org/protocol/muc#admin'><item jid='" +
                                listBox1.Items[0].ToString() + "' affiliation='none'/></query></iq>");
                    listBox1.Items.RemoveAt(0);
                    progressBar1.Value += 1;
                    label.Text = listBox1.Items.Count.ToString();
                }
                else
                {
                    timer1.Enabled = False;
                }
            }
        }
