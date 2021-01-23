    class myForm : Form
    {
        protected void OnClick()
        {
            try
            {
                var data = Helper.SelectStudent();
                // do something
            }
            catch (Exception ex)
            {
                lblInfo.Text = "...";
            }
        }
        class HelperClass
        {
            public static DataTable SelectStudent()
            {
                try
                {
                    //...
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
