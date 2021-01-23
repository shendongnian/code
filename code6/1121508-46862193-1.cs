    private void Form1_Load(object sender, EventArgs e)
        {
           // richTextBox1.Width = 480;
            richTextBox1.Text =
                "value1\tvalue2\tvalue3\tvalue4\tvalue5\tvalue6\n" +
                "value1\tvalue2\tvalue3\tvalue4\tvalue5\tvalue6\n" +
                "value1\tvalue2\tvalue3\tvalue4\tvalue5\tvalue6\n" +
                "value1\tvalue2\tvalue3\tvalue4\tvalue5\tvalue6";
            richTextBox1.SelectAll();
            //------------------------------------- value1
            //------------------------------------------ value2
            //----------------------------------------------- value3
            //---------------------------------------------------- value4
            //--------------------------------------------------------- value5
            richTextBox1.SelectionTabs = new int[] { 50, 100, 150, 200, 250 };
            //-----------------------------------------------------------------
            richTextBox1.AcceptsTab = true;
            richTextBox1.Select(0, 0);
        }
