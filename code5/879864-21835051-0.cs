    //Break links
    System.Array links = (System.Array) ((object)targetWorkbook.LinkSources(XlLink.xlExcelLinks));
    if (links != null)
    {
        for (int i = 1; i <= links.Length; i++)
        {
            try
            {
                targetWorkbook.UpdateLink((string)links.GetValue(i),
                            XlLinkType.xlLinkTypeExcelLinks);
                targetWorkbook.BreakLink((string)links.GetValue(i),
                            XlLinkType.xlLinkTypeExcelLinks);
            }
            catch (Exception ex)
            {
                Tools.LogException(ex, "targetWorkbook.BreakLink");
            }
        }
    }
