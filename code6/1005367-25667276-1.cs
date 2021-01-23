    private void btn_compare_Click(object sender, EventArgs e)
    {
        string x1 = System.IO.File.ReadAllText(FindFile(), Encoding.UTF8);
        string x2 = System.IO.File.ReadAllText(FindFile(), Encoding.UTF8);
        //Or if you already have the second file
        //string x2 = System.IO.File.ReadAllText(@"C:\YourPath\someFileName.xml", Encoding.UTF8);
        compare.comparison(x1, x2);
    }
