    Page2.aspx.cs
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        MyWebMethod();
    }
    
    [WebMethod]
    public static void MyWebMethod ()
    {
        //... Do something useful
    }
    
    Page1.aspx
    
    <script>
        function callMyWebMethod(){
            PageMethods.MyWebMethod(function(){ // success callback}, function(){ // error callback});
        }
    </script>
