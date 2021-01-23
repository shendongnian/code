    static private void generateCRFlight(DataTable inDataTable)
        {
            //Create data set to be consumed by crystal report
            DataSetFlight dataSetFlight = new DataSetFlight();
            DataTable theDataTable = dataSetFlight.Tables.Add(("FlightData"));
            theDataTable.Columns.Add("CarrID", Type.GetType("System.String"));
            theDataTable.Columns.Add("ConnID", Type.GetType("System.String"));
            theDataTable.Columns.Add("FlDate", Type.GetType("System.DateTime"));
            theDataTable.Columns.Add("Price", Type.GetType("System.Decimal"));
            theDataTable.Columns.Add("Currency", Type.GetType("System.String"));
            theDataTable.Columns.Add("PlaneType", Type.GetType("System.String"));
            theDataTable.Columns.Add("SeatsMax", Type.GetType("System.Int32"));
            theDataTable.Columns.Add("SeatsOcc", Type.GetType("System.Int32"));
     
            int rowCounter = 0;
            int numberOfRows = inDataTable.Rows.Count;
     
            for (rowCounter = 0; rowCounter < numberOfRows; rowCounter++)
            {
                DataRow theDataRow = theDataTable.NewRow();
                theDataRow[0] = inDataTable.Rows[rowCounter][0];
                theDataRow[1] = inDataTable.Rows[rowCounter][1];
                theDataRow[2] = inDataTable.Rows[rowCounter][2];
                theDataRow[3] = inDataTable.Rows[rowCounter][3];
                theDataRow[4] = inDataTable.Rows[rowCounter][4];
                theDataRow[5] = inDataTable.Rows[rowCounter][5];
                theDataRow[6] = inDataTable.Rows[rowCounter][6];
                theDataTable.Rows.Add(theDataRow);
            }
     
            CRFlight theCrystalReport = new CRFlight();
            theCrystalReport.SetDataSource(dataSetFlight.Tables[1]);
            ReportViewer theReportViewer = new ReportViewer(theCrystalReport);
            theReportViewer.Show();
        }
 
