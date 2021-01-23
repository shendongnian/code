         MySqlConnection conn;
         MySqlCommand cmd;
         MySqlDataAdapter adap;
        // Code to get data from database
        conn = new MySqlConnection("Server=localhost; Database=dbname; User ID=root; Password=; charset=utf8;");
        conn.Open();
        cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT photo_path,title, firstname FROM student_details WHERE `register_no`='" + Reg_No + "' ";
        adap = new MySqlDataAdapter();
        adap.SelectCommand = cmd;
        
        TC_Dataset StudentDB = new TC_Dataset();    //TC_Dataset is the Dataset name, which you have created.
        StudentDB.Clear();
        adap.Fill(StudentDB, "TC_dt");     // TC_dt is the DataTable name in the Dataset
        // Create a CrystalReport1 object 
        TC_Report myReport = new TC_Report();    //TC_Report is the name of the Crystal Report (rpt file)
        TextObject txt1 = (TextObject)myReport.ReportDefinition.Sections["Section1"].ReportObjects["Text68"]; **//  this is used to send the data from text box to CR (Text68) is the textfield name in CR, Year_leaving contains the date of the textbox as string.**
        txt1.Text = Year_leaving;
        TextObject txt2 = (TextObject)myReport.ReportDefinition.Sections["Section1"].ReportObjects["Text21"];
        txt2.Text = reason_leaving;
        // Set the DataSource of the report
        myReport.SetDataSource(StudentDB);
        // Set the Report Source to ReportView 
        crystalReportViewer1.ReportSource = myReport;  //crystalReportViewer1 is the CR Viewer name which is in the form 
