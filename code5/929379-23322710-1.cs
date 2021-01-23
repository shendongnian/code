    ReportDocument cryRpt = new ReportDocument();
           
            string rpt = "CrystalReport1.rpt";
            string reportFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            
            string reportPath = Path.Combine(reportFolder, rpt);
            if(!File.Exists(reportPath))
            {
                 MessageBox.Show("File " + rpt + " not found in " + reportFolder );
                 return;
            }
            cryRpt.Load(reportPath);
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
