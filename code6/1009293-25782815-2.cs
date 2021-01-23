        void export_Click(object sender, EventArgs e){
            byte[] data = File.ReadAllBytes("export.xls"); //The created excel file with the library, if the library supports getting the excel as a stream you can use the method below to stream it.
            string filename = "export.xls"; 
         
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename="+filename);
            Response.AddHeader("Content-Type", "application/Excel");
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("Content-Length", bytesInStream.Length.ToString());
            Response.BinaryWrite(data);
            Response.End();       
        }
