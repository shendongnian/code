    private void Form1_Load(object sender, EventArgs e)
    {
        //text to hold the conbo box, text is grabed from the AS2W14data.csv file from c:\temp\...
        String variable;
        variable = "";
        ArrayList Indexs = new ArrayList();
        //filll in the combo box , create a reader
        System.IO.StreamReader sr = System.IO.File.OpenText(@"c:\temp\AS2W14data.csv");
        //use a while loop to read the entire file line by line, using the current line to populate the comboBox
        while (!sr.EndOfStream)
        {
            variable = sr.ReadLine();
            string[] currentLineIndex = variable.Split(',');
            //customer ID is indexed at the string array postion 1
            //Customer name is indexed at the string array position 0
            Indexs.Add(new AddIndexValues(currentLineIndex[1].Trim() + " " + currentLineIndex[0].Trim());
        }
        //close the file to prevent errors...
        cboCustomer.DataSource = DataBaseBuilds.Indexs;
        sr.Close();
    }
    public class AddIndexValues
    {
       private int i_index;
       public AddIndexValues(int Index)
       {
          i_index = Index;
       }
       public int Index
       {
          get { return i_index; }
       }
    }
