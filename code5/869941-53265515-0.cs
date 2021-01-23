    Word.Document document = ThisAddIn.Instance.Application.ActiveDocument;
    var rangeAll = document.Range();
    				rangeAll.TextRetrievalMode.IncludeHiddenText = true;
    				foreach (Microsoft.Office.Interop.Word.Range p in rangeAll.Words)
    				{					
    					texts += p.Text;
    					if (p.Font.Hidden != 0) //Hidden text found
    					{
    						p.Font.Hidden = 0;
    						count++;
    					}
    				}
