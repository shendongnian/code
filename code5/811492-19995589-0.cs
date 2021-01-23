	private void GenerateHtmlText(List<TorTeeFileBO> torTeeFileBos)
    {
        StringBuilder pageText = new StringBuilder();
        StringBuilder htmlText = new StringBuilder();
        StringBuilder styleText = new StringBuilder();
        List<TorTeeFileBO> allTorteeFilesEven = new List<TorTeeFileBO>();
        List<TorTeeFileBO> singleTorteeFile = new List<TorTeeFileBO>();
        int maxItem = 0;
        bool isDataFound = false;
        if (torTeeFileBos.Count % 2 == 0)
        {
            allTorteeFilesEven = torTeeFileBos;
        }
        else
        {
            for (int i = 0; i < torTeeFileBos.Count; i++)
            {
                if (i == torTeeFileBos.Count - 1)
                {
                    singleTorteeFile.Add(torTeeFileBos[i]);
                }
                else
                {
                    allTorteeFilesEven.Add(torTeeFileBos[i]);
                }
            }
        }
        pageText.Append("<html><head><title>QC Print</title></head><body>");
        
        if (torTeeFileBos.Count > 0)
        {
            for (int i = 0; i < allTorteeFilesEven.Count; i += 2)
            {
                maxItem = 0;
                isDataFound = false;
                htmlText.Append("<table>");
                htmlText.Append("<tr>");
                // 1st Row, 1st Column for Batch Name
                htmlText.Append("<td>");
                htmlText.Append("<b>");
                htmlText.Append("QC: ");
                htmlText.Append(cmbUsers.Text);
                htmlText.Append("</b>");
                htmlText.Append("</td>");
                htmlText.Append("<td>");
                htmlText.Append("<b>");
                htmlText.Append(" ; Batch No. : ");
                htmlText.Append(allTorteeFilesEven[i].FriendlyFileName);
                htmlText.Append("</b>");
                htmlText.Append("</td>");
                htmlText.Append("<td width='50px'></td>");
                // 1st Row, 2nd Column for Batch Name
                htmlText.Append("<td>");
                htmlText.Append("<b>");
                htmlText.Append("QC: ");
                htmlText.Append(cmbUsers.Text);
                htmlText.Append("</b>");
                htmlText.Append("</td>");
                htmlText.Append("<td>");
                htmlText.Append("<b>");
                htmlText.Append(" ; Batch No. : ");
                htmlText.Append(allTorteeFilesEven[i+1].FriendlyFileName);
                htmlText.Append("</b>");
                htmlText.Append("</td>");
                htmlText.Append("</tr>");
                StringBuilder tableHtml = new StringBuilder();
                if (allTorteeFilesEven[i].FileData.Count > allTorteeFilesEven[i+1].FileData.Count)
                {
                    maxItem = allTorteeFilesEven[i].FileData.Count;
                }
                else if ((allTorteeFilesEven[i].FileData.Count < allTorteeFilesEven[i + 1].FileData.Count) || 
                    (allTorteeFilesEven[i].FileData.Count == allTorteeFilesEven[i + 1].FileData.Count))
                {
                    maxItem = allTorteeFilesEven[i+1].FileData.Count;
                }
                for (int j = 0; j < maxItem; j++)
                {
                    tableHtml.Append("<tr>");
                    //1st Column Data
                    tableHtml.Append("<td>");
                    isDataFound = false;
                    try
                    {
                        tableHtml.Append(allTorteeFilesEven[i].FileData[j].Rec_Num);
                        isDataFound = true;
                    }
                    catch
                    {
                        tableHtml.Append("");
                        isDataFound = false;
                    }
                    tableHtml.Append("</td>");
                    if(isDataFound)
                    {
                        tableHtml.Append("<td>________________</td>");    
                    }
                    else
                    {
                        tableHtml.Append("<td></td>"); 
                    }
                    //Column Separator
                    tableHtml.Append("<td width='50px'></td>");
                    //2nd Column Data
                    tableHtml.Append("<td>");
                    isDataFound = false;
                    try
                    {
                        tableHtml.Append(allTorteeFilesEven[i+1].FileData[j].Rec_Num);
                        isDataFound = true;
                    }
                    catch
                    {
                        tableHtml.Append("");
                        isDataFound = false;
                    }
                    tableHtml.Append("</td>");
                    if (isDataFound)
                    {
                        tableHtml.Append("<td>________________</td>");
                    }
                    else
                    {
                        tableHtml.Append("<td></td>");
                    }
                    tableHtml.Append("</tr>");
                }
                htmlText.Append(tableHtml);
                htmlText.Append("<tr></tr>");
                htmlText.Append("</table>");
            }
            if (singleTorteeFile.Count > 0)
            {
                StringBuilder singleHtml = new StringBuilder();
                singleHtml.Append("<table>");
                singleHtml.Append("<tr>");
                // 1st Row, 1st Column for Batch Name
                singleHtml.Append("<td>");
                singleHtml.Append("<b>");
                singleHtml.Append("QC: ");
                singleHtml.Append(cmbUsers.Text);
                singleHtml.Append("</b>");
                singleHtml.Append("</td>");
                singleHtml.Append("<td>");
                singleHtml.Append("<b>");
                singleHtml.Append(" ; Batch No. : ");
                singleHtml.Append(singleTorteeFile[0].FriendlyFileName);
                singleHtml.Append("</b>");
                singleHtml.Append("</td>");
                singleHtml.Append("<td width='50px'></td>");
                // 1st Row, 2nd Column for Batch Name
                singleHtml.Append("<td>");
                singleHtml.Append("");
                singleHtml.Append("");
                singleHtml.Append("</td>");
                singleHtml.Append("<td>");
                singleHtml.Append("");
                singleHtml.Append("</td>");
                singleHtml.Append("</tr>");
                StringBuilder singleTableHtml = new StringBuilder();
                for (int j = 0; j < singleTorteeFile[0].FileData.Count; j++)
                {
                    singleTableHtml.Append("<tr>");
                    singleTableHtml.Append("<td>");
                    singleTableHtml.Append(singleTorteeFile[0].FileData[j].Rec_Num);
                    singleTableHtml.Append("</td>");
                    singleTableHtml.Append("<td>________________</td>");
                    singleTableHtml.Append("</tr>");
                }
                singleHtml.Append(singleTableHtml);
                singleHtml.Append("</table>");
                htmlText.Append(singleHtml);
            }
        }
        pageText.Append(styleText);
        pageText.Append(htmlText);
        pageText.Append("</body></html>");
        wbPagePreview.DocumentText = pageText.ToString();
    }
