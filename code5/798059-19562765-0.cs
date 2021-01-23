    List<String> webHistory;
    int curIndex = -1;
    public Form1()
    {
        InitializeComponent();
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        webHistory = new List<string>();
    }
    
    private void gotoUrl(string curUrl)
    {
        //display the url in the browser
    }
    
    
    private void addUrl(string curUrl)
    {
        //Add a new Url
        if (webHistory.Count > 0 && webHistory.Count - 1 > curIndex) webHistory.RemoveRange(curIndex, webHistory.Count - curIndex - 1);
        webHistory.Add(curUrl);
        curIndex = webHistory.Count - 1;
    
        gotoUrl(curUrl);
    }
    
    
    private void Previous_Click(object sender, EventArgs e)
    {
        if (curIndex - 1 >= 0)
        {
            //Previous URL
            curIndex = curIndex - 1;
            gotoUrl(webHistory[curIndex]);
        }
    }
    
    private void Next_Click(object sender, EventArgs e)
    {
        if (curIndex + 1 <= webHistory.Count - 1)
        {
            //Next URL
            curIndex = curIndex + 1;
            gotoUrl(webHistory[curIndex]);
        }
    }
    
    private void Navigate_Click(object sender, EventArgs e)
    {
        //Simulate the user input by introducing new URLs
        addUrl("");
    }
