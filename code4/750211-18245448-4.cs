    class TextBoxAndString
    {
        public TextBox tb {get; set;}
        public String s {get; set;}
    }
    .ctor() //the form's constructor
    {
        btnOne.Tag = new TextBoxAndString {tb = tbOne, s = "This text is from button one"};
        btnTwo.Tag = new TextBoxAndString {tb = tbTwo, s = "This is some different text"};
        btnThree.Tag = new TextBoxAndString {tb = tbThree, s = "Button three text"};   
    } 
    void Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        TextBoxAndString tbs = (TextBoxAndString)btn.Tag;
        tbs.tb.Text = tbs.s;
    }
