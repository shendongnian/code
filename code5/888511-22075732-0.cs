    protected void btnGuess_Click(object sender, EventArgs e)
    {
            int randomNum = Convert.ToInt32(HttpContext.Current.Session["RANDOM"]);
            int guessedNum = Convert.ToInt32(txtGuess.Text);
            if (guessedNum < randomNum)
            {
                MessageBox.Show("No. Low.");
                txtGuess.Text = "";
            }
            else if (guessedNum > randomNum)
            {
                MessageBox.Show("No. High.");
                txtGuess.Text = "";
            }
            else
            {
                MessageBox.Show("Yes");
                txtGuess.Text = "";
            }
        }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false) //the code only runs once when the form is loaded.
        {
            Random myGenerator = new Random();
            myGenerator = new Random();
           int randomNum = myGenerator.Next(1, 50);
           HttpContext.Current.Session["RANDOM"] = randomNum;
        }
    }
   
