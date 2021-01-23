     private void Button_extract_element_Click(object sender, EventArgs e)
     {
     TestObject test = new TestObject();
     test._shouldstop = true;
     backgroundWorker1.RunWorkerAsync(test);
     int passes = 0;
     Label_extract_element.Text = "wait processing....";
     Label_extract_element.Refresh();
     Label_extract_element.Update();
     //this should keep winform waiting for thread-return, showing passes
     while (test._shouldstop)
     {
        passes++;
        Label_extract_element.Text = "wait processing...." + passes;
        Label_extract_element.Refresh();
        Label_extract_element.Update();
     }
     Label_extract_element.Text = " OK, done!";
     Label_extract_element.Refresh();
     Label_extract_element.Update();
     } //End of Button_extract_element_Click
     class TestObject
     {
     public bool _shouldstop { get; set; }
     }   
     //backgroundWorker complete actions 
     private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
     {
        // Receive the result from DoWork, and display it.
        TestObject test = e.Result as TestObject;
     }
     private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
     {
     TestObject argumentTest = e.Argument as TestObject;
     argumentTest._shouldstop = true;
     string loop = "";
     string[] ListOfFilesinDir = Directory.GetFiles(GlobalVariables.folder, "*.txt").Select(Path.GetFileName).ToArray();
     foreach (string filename in ListOfFilesinDir)
     {
        int count_barr = 0;
        int count_lines = 0;
        //ReadAll seems to process really fast - not a gap
        string[] FLines = File.ReadAllLines(GlobalVariables.folder + "\\" + filename);
        int[] line_barr = new int[FLines.Count()];
        foreach (string Lines in FLines)
        {
        count_lines++;
        switch (Lines)
        {
           case "SE;":
           GlobalVariables.SEstr = FLines[count_lines].Split(';')[3].Trim();
           break;
           case "CKT;":
           GlobalVariables.codCktAL = FLines[count_lines].Split(';')[2].Trim();
           GlobalVariables.nomeCktAL = FLines[count_lines].Split(';')[10].Trim();
           GlobalVariables.nomeArqv = filename;
           break;
           case "BARR;": loop = "BARR;"; break;
           case "TRECH;": loop = "TRECH;"; break;
           case "CAP;": loop = "CAP;"; break;
           case "INST;": loop = "INST;"; break;
           case "KEY;": loop = "KEY;"; break;
           case "REG;": loop = "REG;"; break;
           case "DMD;": 
              loop = "DMD;"; 
              GlobalVariables.TRAFO = (FLines[count_lines-8].Split(';')[1].Trim());
              break;
        }
        switch (loop)
        {
           // I'll post just the first case, so I dont go soooo long in this post..
           //This part seems to process really fast
           case "BARR;":
              GlobalVariables.parse_results = "";
              //take next line and test if is one of the nexts TAGs, and break loop:
              GlobalVariables.parse_results += FLines[count_lines];
              if (Equals(GlobalVariables.parse_results, "TRECH;") || Equals(GlobalVariables.parse_results, "CAP;") || Equals(GlobalVariables.parse_results, "INST;") || Equals(GlobalVariables.parse_results, "KEY;") || Equals(GlobalVariables.parse_results, "REG;") || Equals(GlobalVariables.parse_results.Split(';')[0], "ET") || Equals(GlobalVariables.parse_results.Split(';')[0], "EP"))
              {
                 GlobalVariables.parse_results = "";
                 loop = "";
                 break;
              }
              else  
              {
                 //store the number of the line to array for later reference
                 count_barr++;
                 line_barr[count_barr] = count_lines;
                 break;
              }
              case "TRECH;": /*repeat all in BARR loop for TRECH's 20 fields*/ break;
              case "CAP;": /*same repeat for different n fields*/ break;
              case "INST;": /*same repeat for different n fields*/ break;
              case "KEY;": /*same repeat for different n fields*/ break;
              case "REG;": /*same repeat for different n fields*/ break;
        } //end of switch
     } //end for each lines
    string dbName = Application.StartupPath + "\\Resources";
    DAO.DBEngine dbEngine = new DAO.DBEngine();
    DAO.Database db = dbEngine.OpenDatabase(dbName+"\\DataBase.accdb");
    // From here, could work more to store different Tables with different fields, dynamically, improving code
    DAO.Recordset rs = db.OpenRecordset("BARRA_MT");   
                 
    for (int i = 1; i < (count_barr+1); i++)
    {
       rs.AddNew();
       double b0 = Convert.ToDouble(FLines[line_barr[i]].Split(';')[0].Trim());
       string b1 = FLines[line_barr[i]].Split(';')[1].Trim().ToString();
       double b2 = Convert.ToDouble(FLines[line_barr[i]].Split(';')[2].Trim());
       double b3 = Convert.ToDouble(FLines[line_barr[i]].Split(';')[3].Trim());
       rs.Fields["BARR_MT"].Value = b0;
       rs.Fields["COD"].Value = b1;
       rs.Fields["X"].Value = b2;
       rs.Fields["Y"].Value = b3;
       rs.Update();
    }
    rs.Close();     
    db.Close();
    argumentTest._shouldstop = false;
    e.Result = argumentTest;
    } //end`
