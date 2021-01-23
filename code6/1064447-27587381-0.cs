    protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Enabled = false;
            for (int x = 1; x < 6; x++)
            {
                ViewState["progress"] += "Beginning Processing Step " + x.ToString() + " at " + DateTime.Now.ToLongTimeString() + "..." + System.Environment.NewLine;
                System.Threading.Thread.Sleep(1000); //to simulate a process that takes 1 second to complete.
                ViewState["progress"] += "Completed Processing Step " + x.ToString() + " at " + DateTime.Now.ToLongTimeString() + System.Environment.NewLine;
                TextBox1.Text += ViewState["progress"].ToString();
            }
        }
