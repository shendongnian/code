        public void ExportToWordUsingTemplate()
        {
            
            Aspose.Words.Document doc1 = new Aspose.Words.Document(@"E:/excel/HOVEDMAL Prognoserapporter 2.dotx");
            DocumentBuilder docBuilder1 = new DocumentBuilder(doc1);
            SkinAPI.ReportAPISoapClient svc = new SkinAPI.ReportAPISoapClient();
            SkinAPI.GetReportContextResult myReportContext = svc.GetReportContext(1);
            docBuilder1.InsertHtml("<h1 align='left'>" + myReportContext[0].MainReportName + "</h1>");
            docBuilder1.InsertTableOfContents("\\o \"1-3\" \\h \\z \\u");
            //for (int i = 0; i < myReportContext.Count - 2; i++)
            for (int i = 0; i < 5; i++)
            {
                SkinAPI.GetReportElementGraphDataResult myElementGraphData = svc.GetReportElementGraphData(myReportContext[i].ReportId, myReportContext[i].ElementId);
                SkinAPI.GetReportElementDataResult myElementData = svc.GetReportElementData(myReportContext[i].ReportId, myReportContext[i].ElementId, 0, 0, 0);    // Three last parameters set to 0, used when fetching drilldown data for tables that support it
                docBuilder1.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading1;
                docBuilder1.Writeln(myReportContext[i].ElementHeader);
                docBuilder1.ParagraphFormat.StyleIdentifier = StyleIdentifier.BodyText;
                // Is there a graph for this element, and has it a datasource other than the main data source as fetched above?
                if (myReportContext[i].HasGraph && myReportContext[i].SeparateGraphDataSource)
                {
                    // Is there a text part for this element
                    if (myReportContext[i].HasText)
                    {
                        // The returned string will contain a HTML text.
                        // Note that the text is connected to a TileId, not an ElementId, meening the text might have been fetched before.
                        string myElementHTMLDescription = svc.GetReportText(myReportContext[i].TileId);
                        docBuilder1.InsertHtml(myElementHTMLDescription);                        
                    }
                }
                docBuilder1.InsertBreak(BreakType.PageBreak);
            }
            doc1.Save(@"E:/excel/HOVEDMAL Prognoserapporter 2_Report.doc");
        }
