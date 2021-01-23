    System.IO.StreamReader fileToPrint;
    System.Drawing.Font printFont;
    private void printButton_Click(object sender, EventArgs e)
    {
      string printPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      fileToPrint = new System.IO.StreamReader(printPath + @"\myFile.txt");
      printFont = new System.Drawing.Font("Arial", 10);
      printDocument1.Print();
      fileToPrint.Close();
    }
