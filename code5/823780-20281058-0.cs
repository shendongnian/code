     int listNumber = 1;
     foreach (Paragraph p in this.Application.ActiveDocument.Paragraphs)
            {
                if (p.Range.ListFormat.ListType != WdListType.wdListNoNumbering)
                {
                    p.Range.ListFormat.ApplyListTemplate(
                        ListTemplate: this.Application.ActiveDocument.ListTemplates[listNumber],
                        ContinuePreviousList: true,
                        ApplyTo: Microsoft.Office.Interop.Word.WdListApplyTo.wdListApplyToWholeList,
                        DefaultListBehavior: Microsoft.Office.Interop.Word.WdDefaultListBehavior.wdWord10ListBehavior);
                }
            }
