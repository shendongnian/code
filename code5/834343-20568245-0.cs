    xmlData myXML = new xmlData();
    public struct xmlData
    {
         public string xmlAttribute;   
    }
    private void Show_btn_Click(object sender, EventArgs e)
    {
                //do something.....
           myXML.xmlAttributes = "blah"
    }
    private void Submit_btn_Click(object sender, EventArgs e)
    {
     //I want to call myXML.xmlAttributes retrieving the stored value from Show_btn_Click
    }
