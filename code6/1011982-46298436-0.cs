    private static void BreakAllExternalLinks(Excel.Workbook wbFrom, Excel.Workbook wbTo)
        {
            Array links = (Array)((object)wbTo.LinkSources(Excel.XlLink.xlExcelLinks));
            if (links != null)
            {
                foreach (object o in links)
                {
                    string link = o as string;
                    if (link == wbFrom.FullName)
                    {
                        wbTo.ChangeLink(link, wbTo.FullName, Excel.XlLinkType.xlLinkTypeExcelLinks);
                    }
                }
            }
        }
