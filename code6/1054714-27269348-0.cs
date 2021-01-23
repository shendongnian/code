    private void contextMenu_Opening(object sender, CancelEventArgs e)
            {
                if (Clipboard.GetDataObject().GetFormats()[0] == System.Windows.Forms.DataFormats.StringFormat)
                {
                    pasteToolStripMenuItem.Enabled = true;
                }
                else
                {
                    pasteToolStripMenuItem.Enabled = false;
                }
    
                IHTMLDocument2 htmlDocument = MainBrowser.Document.DomDocument as IHTMLDocument2;
                IHTMLSelectionObject currentSelection = htmlDocument.selection;
                if (currentSelection.type == "Text")
                {
                    IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;
                    if (range.text != "null" || !String.IsNullOrEmpty(range.text.Trim()))
                    {
                        copyToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        copyToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    copyToolStripMenuItem.Enabled = false;
                }
            }
