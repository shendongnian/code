        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tag_NumbersDataSet.NEW_SO_TAG_NUMBER' table. You can move, or remove it, as needed.
            DBConn = ConfigurationManager.ConnectionStrings[@"C:\Users\MyName\Documents\Visual Studio 2012\Projects\Tag Number\Tag Number\Tag Numbers.sdf"].ConnectionString; //Do it here.....
            this.nEW_SO_TAG_NUMBERTableAdapter.Fill(this.tag_NumbersDataSet.NEW_SO_TAG_NUMBER);
        }
