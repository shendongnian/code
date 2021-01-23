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
    
                ToolStripMenuItem tsmiUndo = new ToolStripMenuItem("Undo");
                tsmiUndo.Click += (sender, e) => { if (CanUndo) Undo(); };
                tsmiUndo.ShortcutKeys = Keys.Z | Keys.Control;
                cms.Items.Add(tsmiUndo);
                ToolStripMenuItem tsmiRedo = new ToolStripMenuItem("Redo");
                tsmiRedo.Click += (sender, e) => { if (CanRedo) Redo(); };
                tsmiRedo.ShortcutKeys = Keys.Y | Keys.Control;
                cms.Items.Add(tsmiRedo);
                cms.Items.Add(new ToolStripSeparator());
                ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Cut");
                tsmiCut.Click += (sender, e) => Cut();
                tsmiCut.ShortcutKeys = Keys.X | Keys.Control;
                cms.Items.Add(tsmiCut);
    
                ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copy");
                tsmiCopy.Click += (sender, e) => Copy();
                tsmiCopy.ShortcutKeys = Keys.C | Keys.Control;
                cms.Items.Add(tsmiCopy);
    
                ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Paste");
                tsmiPaste.Click += (sender, e) => Paste();
                tsmiPaste.ShortcutKeys = Keys.V | Keys.Control;                
                cms.Items.Add(tsmiPaste);
    
                ToolStripMenuItem tsmiDelete = new ToolStripMenuItem("Delete");
                tsmiDelete.Click += (sender, e) => { SelectedText = ""; };                                
                cms.Items.Add(tsmiDelete);
    
                cms.Items.Add(new ToolStripSeparator());
    
                ToolStripMenuItem tsmiSelectAll = new ToolStripMenuItem("Select All");
                tsmiSelectAll.Click += (sender, e) => { SelectionStart = 0; SelectionLength = Text.Length; };
                tsmiSelectAll.ShortcutKeys = Keys.A | Keys.Control;
                cms.Items.Add(tsmiSelectAll);
    
                cms.Opening += delegate (object sender, CancelEventArgs e) 
                {
                    tsmiUndo.Enabled = CanUndo && !this.ReadOnly;
                    tsmiRedo.Enabled = CanRedo && !this.ReadOnly;
                    tsmiCut.Enabled = (SelectionLength != 0) && !this.ReadOnly;
                    tsmiCopy.Enabled = SelectionLength != 0;
                    tsmiPaste.Enabled = Clipboard.ContainsText() && !this.ReadOnly;
                    tsmiDelete.Enabled = (SelectionLength != 0) && !this.ReadOnly;
                };
                ContextMenuStrip = cms;
            }
        }
    }
