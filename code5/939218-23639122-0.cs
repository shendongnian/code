    using SpreadsheetGear;
    using SpreadsheetGear.Commands;
    public class MyCommandManager : CommandManager
    {
        internal MyCommandManager(IWorkbookSet workbookSet)
            : base(workbookSet)
        { }
        ...
        // Gets called anytime a Paste command is invoked (i.e., Ctrl+V, context 
        // menu item, WorkbookView.Paste(), etc)
        public override Command CreateCommandPaste(IRange range)
        {
            // Anytime a Paste command is invoked, we'll force a "Paste Values" so 
            // that values are pasted but not cell formatting, which could remove 
            // cell validation.
            return new MyCommandPasteSpecial(range, PasteType.Values, 
                PasteOperation.None, false, false);
        }
        ...
    }
