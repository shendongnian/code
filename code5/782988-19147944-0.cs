    //-snip-
    private Dictionary<char, int> States;
    //-snip-
    public Form1()
    {
        States = new Dictionary<char, int>();
        States.add('A', 4);
        States.add('B', 0);
        States.add('C', 3);
        States.add('D', 1);
        //... etc.
    }
    //-snip-
    private void btnClick_Click(object sender, EventArgs e)
    {
        char myLetter = txtboxEnter.Text.Trim()[0]; // do some other input sanitation here
        int result = States[myLetter];
        lblDisplay.Text = Convert.ToString(result); // consider making your Dictionary <char, string> so you can skip the conversion here
    }
