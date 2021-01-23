        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session.Contents.Count == 0)
                Response.Redirect("Default.aspx");
            d = new ElDelegado(ChangeText);
            Thread t = new Thread(new ThreadStart(ElThread));
            t.IsBackground = true;
            t.Start();
            t.Join();
        }
