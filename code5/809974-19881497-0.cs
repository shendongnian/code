    //Whatever other usings you want
    using System.Windows.Forms;  //Include the win forms namespace so you create the form
    namespace ClassLibrary1
    {
    public static class Class1
    {
        public static Form CreateNewForm()
        {
            var form1 = new Form();
            form1.Width = 200;
            form1.Height = 200;
            form1.Visible = true;
            form1.Activate();        //Unsure if you need to call Activate...
            //You're going to want to modify all the values you want the splash screen to have here
            return form1;
        }   
    }
