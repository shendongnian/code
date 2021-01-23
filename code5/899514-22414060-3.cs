    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        System.Web.Script.Serialization.JavaScriptSerializer o = new System.Web.Script.Serialization.JavaScriptSerializer();
        Argument arg = o.Deserialize<Argument>(((ImageButton)sender).CommandArgument);
    }
    class Argument
    {
        // these property names, must be the same with what you set in 
        // CommandArgument where you write, for example : ... ='<%# "{\"Product_id\": \""+  ...
        // i assume the type of Product_id is guid
        public Guid Product_id { get; set; }
        // i assume the type of Price is decimal
        public decimal Price { get; set; }
    }
