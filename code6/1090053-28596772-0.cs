    bool AreSheetsIdentical(SLDocument doc1, SLDocument doc2)
    {
        SLWorksheetStatistics stats1 = doc1.GetWorksheetStatistics();
        SLWorksheetStatistics stats2 = doc2.GetWorksheetStatistics();
       
        for (int i = 1; i < stats1.EndColumnIndex; i++)
        {
            for (int j = 1; j < stats1.EndRowIndex; j++)
            {
                 if (doc1.GetCellValueAsString(i, j) != doc2.GetCellValueAsString(i, j))
                     return false;
                 if (doc1.GetCellStyle(i, j) != doc2.GetCellStyle(i, j))
                     return false;
             }
         }
         return true;
    }
