    public class Airport : Form
    {
        public RadioButon rb2;
        public void rb2_Checked(Object sender, EventArgs e)
        {
            if (rb2 != null && rb2.Checked)
            {
                thread3 = new Thread(new ParameterizedThreadStart(p2.Start2));
                thread3.Start(this);
            }
        }
    } 
