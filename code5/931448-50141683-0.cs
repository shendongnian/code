    if (DTE.ActiveWindow.Selection.IsEmpty)
    {
       DTE.ActiveWindow.Selection.MoveLeft(FALSE);
       DTE.ActiveWindow.Selection.MoveRight(TRUE);
    }
    string curWord = DTE.ActiveWindow.Selection.Text;
