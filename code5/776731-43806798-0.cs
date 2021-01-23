    namespace Common
    {
        public partial class RichTextBoxEx : RichTextBox
        {
            public RichTextBoxEx()
            {
                AddContextMenu();
            }
    
            public void AddContextMenu()
            {
                ContextMenuStrip cms = new ContextMenuStrip { ShowImageMargin = false };
                cms.Opening += new CancelEventHandler(ContextMenuOpening);
    
                ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Cut");
                tsmiCut.Click += (sender, e) => Cut();
                cms.Items.Add(tsmiCut);
    
                ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copy");
                tsmiCopy.Click += (sender, e) => Copy();
                cms.Items.Add(tsmiCopy);
    
                ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Paste");
                tsmiPaste.Click += (sender, e) => Paste();
                cms.Items.Add(tsmiPaste);
    
                ToolStripMenuItem tsmiDelete = new ToolStripMenuItem("Delete");
                tsmiDelete.Click += (sender, e) => { SelectedText = ""; };
                cms.Items.Add(tsmiDelete);
    
                cms.Items.Add(new ToolStripSeparator());
    
                ToolStripMenuItem tsmiSelectAll = new ToolStripMenuItem("Select All");
                tsmiSelectAll.Click += (sender, e) => { SelectionStart = 0; SelectionLength = Text.Length; };
                cms.Items.Add(tsmiSelectAll);
    
                ContextMenuStrip = cms;
            }
    
            private void ContextMenuOpening(object sender, CancelEventArgs e)
            {
                (sender as ContextMenuStrip).Items[0].Enabled = ((sender as ContextMenuStrip).SourceControl as RichTextBoxEx).SelectionLength != 0;
                (sender as ContextMenuStrip).Items[1].Enabled = ((sender as ContextMenuStrip).SourceControl as RichTextBoxEx).SelectionLength != 0;
                (sender as ContextMenuStrip).Items[2].Enabled = Clipboard.ContainsText();
                (sender as ContextMenuStrip).Items[3].Enabled = ((sender as ContextMenuStrip).SourceControl as RichTextBoxEx).SelectionLength != 0;
            }
        }
    }
