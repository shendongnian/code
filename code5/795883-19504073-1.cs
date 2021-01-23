    protected void Page_Load(object sender, EventArgs e)
    {
        // demo purposes to add some data
        if (!Page.IsPostBack)
            bindDemoData();
    }
    private void bindDemoData()
    {
        List<Fruit> fruits = new List<Fruit>();
        fruits.Add(new Fruit() { Name = "Apple" });
        fruits.Add(new Fruit() { Name = "Banana" });
        fruits.Add(new Fruit() { Name = "Orange" });
        fvFruits.DataSource = fruits;
        fvFruits.DataBind();
    }
    /// <summary>
    /// Custom method to check for a given parameter value, which will be given
    /// by the dataBinding within markup code.
    /// You might even pass more parameter values
    /// </summary>
    /// <param name="fruit">the name of the fruit</param>
    /// <returns>custom link for each given fruitName</returns>
    public string customMethod(object fruit)
    {
        if (fruit != null)
        {
            string fruitName = fruit.ToString();
            // insert custom binding here!
            string url = "https://www.mysite.com/Fruit/";
            if (fruitName == "Apple")
                url += "Apples.aspx";
            else if (fruitName == "Banana")
                url += "Banana.aspx";
            else if (fruitName == "Orange")
                url += "Orange.aspx";
            /*else
                url += "defaultFruit.aspx";;  // up to you*/
            // can't see where SeasonLabel and TypeLabel are defined??? please add a comment if I did get you wrong
            url += string.Format("?Season={0}&Color_Date={1}&num={2}", SeasonLabel.Text, TypeLabel.Text, SeasonLabel.Text);
            
            //uncomment this line and comment out the line above to get a working example
            //url += string.Format("?Season={0}&Color_Date={1}&num={2}", "a", "b", "c");
            return url;
        }
        return "https://www.mysite.com/error.aspx"; // probably - but up to you
    }
    protected void fvFruits_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        fvFruits.PageIndex = e.NewPageIndex;
        bindDemoData();
    }
    // demo data container
    public class Fruit
    {
        public string Name { get; set; }
    }
