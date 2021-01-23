    DataTable ProductDetails = sql.ExecuteSelectCommand("SELECT *  FROM Products_Details_View WHERE Supp_Id = " + Session["SuppID"].ToString() + " and Is_Available = 1"); 
    
    using (ExcelPackage pck = new ExcelPackage())
    {
        //Create the worksheet
        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Demo");
        //Load the datatable into the sheet, starting from cell A1. 
        //Print the column names on row 1
        ws.Cells["A1"].LoadFromDataTable(ProductDetails, true);
        //Write it back to the client
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;  filename=ProductDetails.xlsx");
        Response.BinaryWrite(pck.GetAsByteArray());
    }
