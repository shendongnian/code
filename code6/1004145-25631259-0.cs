    private int NumberOfClicks
    {
       get { return (int)(ViewState["NumberOfClicks"] ?? 0 );
       set { ViewState["NumberOfClicks"] = value; }
    }
    
    
    protected void btn_Click(object sender, EventArgs e)
    {
       if(NumberOfClicks < colorArray.Length)
       {
               //write to response colorArray[NumberOfClicks];
               NumberOfClicks += 1;
       }
    }
