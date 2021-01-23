    protected void Page_Load(object sender, EventArgs e)
    {
       for (int i = 1; i <= 9; i++)
       {
           UpdateProgress(i * 10, " Completed.");
           System.Threading.Thread.Sleep(1000);
       }
       UpdateProgress(100, "Finished!");
    }
    protected void UpdateProgress(int PercentComplete, string Message)
    {
        Response.Write(String.Format("<script type=\"text/javascript\">parent.UpdateProgress({0}, '{1}');</script>", PercentComplete, Message));
        Response.Flush();
    }
