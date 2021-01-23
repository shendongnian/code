    private static bool tracing = false;
    public void button3_Click(object sender, EventArgs e)
    {
        if (tracing)
        {
            ps.AddScript("netsh trace stop");
            button3.Text = "Begin trace";
            ps.Invoke();
        }
        else
        {
            ps.AddScript("netsh trace start persistent=yes capture=yes tracefile=" + 
                progpath + @"\nettrace.etl");
            button3.Text = "Stop trace";
        }     
        tracing = !tracing;
    }
