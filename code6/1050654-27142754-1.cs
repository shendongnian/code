    private void yourMethod()
    {
        string srcDoc = dataDir + "ItemsTemplate.docx";
        string dstDoc = dataDir + "ItemsTemplate_Result.docx";
        int totalRecords = 10;
        int recordsPerPage = 4;
        // Prepare some data
        DataSet ds = getData(totalRecords, recordsPerPage);
        // Prepare the document in Aspose
        Aspose.Words.Document doc = new Aspose.Words.Document(srcDoc);
        doc.MailMerge.ExecuteWithRegions(ds);
        doc.MailMerge.CleanupOptions = Aspose.Words.Reporting.MailMergeCleanupOptions.RemoveEmptyParagraphs;
        doc.Save(dstDoc);
        Process.Start(dstDoc);
    }
    private DataSet getData(int totalRecords, int recordsPerPage)
    {
        DataSet ds = new DataSet("Dataset");
            
        // Add the page table
        System.Data.DataTable pageTable = new System.Data.DataTable("Page");
        pageTable.Columns.Add("PageNumber");
        pageTable.Columns.Add("PageTotal");
        pageTable.Columns.Add("PreviousPageTotal");
        // Add the item table
        System.Data.DataTable itemTable = new System.Data.DataTable("Item");
        itemTable.Columns.Add("ID");
        itemTable.Columns.Add("Name");
        itemTable.Columns.Add("Cost");
        itemTable.Columns.Add("PageNumber");
        // Add pages
        int iRow = 1, iPage = 1;
        while (iRow <= totalRecords )
        {
            DataRow pageRow = pageTable.NewRow();
            pageRow["PageNumber"] = iPage;
            pageRow["PageTotal"] = 0;
            // Add the items in this page
            int iRecordsPerPage = 1;
            while (iRow <= totalRecords && iRecordsPerPage <= recordsPerPage)
            {
                DataRow itemRow = itemTable.NewRow();
                itemRow["ID"] = iRow;
                itemRow["Name"] = "Item " + iRow;
                itemRow["Cost"] = iRow;
                itemRow["PageNumber"] = iPage;
                pageRow["PageTotal"] = int.Parse(pageRow["PageTotal"].ToString()) + int.Parse(itemRow["Cost"].ToString());
                itemTable.Rows.Add(itemRow);
                iRow++;
                iRecordsPerPage++;
            }
            pageTable.Rows.Add(pageRow);
            // Previous page total
            if (iPage == 1)
                pageRow["PreviousPageTotal"] = 0; // Always 0 for first page
            else
                pageRow["PreviousPageTotal"] = pageTable.Rows[iPage - 2]["PageTotal"]; // Get total of previous page
            iPage++;
        }
        ds.Tables.Add(pageTable);
        ds.Tables.Add(itemTable);
        // We must have relationship for Aspose mail merge to work correctly
        ds.Relations.Add(pageTable.Columns["PageNumber"], itemTable.Columns["PageNumber"]);
        return ds;
    }
