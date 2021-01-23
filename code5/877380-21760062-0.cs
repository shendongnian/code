    foreach (Section sec in document.Sections)
    {
       foreach (HeaderFooter headerFooter in sec.GetHeadersFooters())
       {
          document.ActiveWindow.View.set_SeekView(headerFooter.IsHeader
                  ? WdSeekView.wdSeekCurrentPageHeader:WdSeekView.wdSeekCurrentPageFooter);
                    **//Insert the shape**
          InsertFromBuildingBlocks(headerFooter.Range);
       }
       document.ActiveWindow.View.set_SeekView(WdSeekView.wdSeekMainDocument);
     }
        //This is extension method used above
        public static IEnumerable<HeaderFooter> GetHeadersFooters(this Section section)
        {
            List<HeaderFooter> headerFooterlist = new List<HeaderFooter>
                {
                    section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary],
                    section.Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage],
                    section.Headers[WdHeaderFooterIndex.wdHeaderFooterEvenPages],
                    section.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary],
                    section.Footers[WdHeaderFooterIndex.wdHeaderFooterFirstPage],
                    section.Footers[WdHeaderFooterIndex.wdHeaderFooterEvenPages]
                };
            return headerFooterlist;
        }
