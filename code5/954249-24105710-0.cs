    accessApp.DoCmd.OpenReport(
            "Report1", 
            Microsoft.Office.Interop.Access.AcView.acViewDesign);
    Microsoft.Office.Interop.Access.Report rpt = accessApp.Reports["Report1"];
    rpt.RecordSource = "SELECT * FROM Clients WHERE ID<=3";
    accessApp.DoCmd.OutputTo(
            Microsoft.Office.Interop.Access.AcOutputObjectType.acOutputReport,
            "",
            "PDF Format (*.pdf)",
            @"C:\Users\Gord\Desktop\zzzTest.pdf",
            false,
            null,
            null,
            Microsoft.Office.Interop.Access.AcExportQuality.acExportQualityPrint);
    // now close the report without saving the change to the RecordSource property
    accessApp.DoCmd.Close(
            Microsoft.Office.Interop.Access.AcObjectType.acReport,
            "Report1",
            Microsoft.Office.Interop.Access.AcCloseSave.acSaveNo);
