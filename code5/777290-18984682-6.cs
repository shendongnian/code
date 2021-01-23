    IDisposable disposable = This.Selection.DeclareChangeBlock();
    using (disposable)
    {
        ITextSelection selection = This.Selection;
        if (!This.AllowOvertype || !This._OvertypeMode)
        {
             flag = false;
        }
        else
        {
             flag = str != "\t";
        }
        ((ITextRange)selection).ApplyTypingHeuristics(flag);
        // SETTING THE CULTURE ->
        This.SetSelectedText(str, InputLanguageManager.Current.CurrentInputLanguage);
        ITextPointer textPointer = This.Selection.End.CreatePointer(LogicalDirection.Backward);
        This.Selection.SetCaretToPosition(textPointer, LogicalDirection.Backward, true, true);
        undoCloseAction = UndoCloseAction.Commit;
    }
