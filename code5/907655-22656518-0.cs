     private void button1_Click(object sender, EventArgs e)
     {
       .....
        //This is NOT global variable initilization!!!!!!
        string[,] tsReqs = new string[rowCount, colCount];
        //.....
        for (int i = 1; i <= rowCount; i++)
        {...
        }
    }
