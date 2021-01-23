    public class Airport : Form
    {
        public RadioButon rb2;
        public void rb2_Checked(Object sender, EventArgs e)
        {
            if (rb2 != null && rb2.Checked)
            {
                var x = new Hubs();
                var thread3 = new Thread(x.Start2);
                thread3.Start(this);
            }
        }
    } 
