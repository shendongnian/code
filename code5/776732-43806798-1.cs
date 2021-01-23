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
    
                cms.Opening += delegate (object sender, CancelEventArgs e) 
                {
                    tsmiCut.Enabled = SelectionLength != 0;
                    tsmiCopy.Enabled = SelectionLength != 0;
                    tsmiPaste.Enabled = Clipboard.ContainsText();
                    tsmiDelete.Enabled = SelectionLength != 0;
                };
                ContextMenuStrip = cms;
            }
        }
    }
