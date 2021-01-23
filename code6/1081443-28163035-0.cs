    private List<int> _matches;
    private string _textToFind;
    private bool _matchCase;
    private int _matchIndex;
    private void MoveToNextMatch(string textToFind, bool matchCase, bool forward)
    {
        if (_matches == null ||
            _textToFind != textToFind ||
            _matchCase != matchCase)
        {
            int startIndex = 0, matchIndex;
            StringComparison mode = matchCase ?
                StringComparison.CurrentCulture :
                StringComparison.CurrentCultureIgnoreCase;
            _matches = new List();
            while (startIndex < TheTextBox.Text.Length &&
                (matchIndex = TheTextBox.Text.IndexOf(textToFind, startIndex, mode)) >= 0)
            {
                _matches.Add(matchIndex);
                startIndex = matchIndex + textToFind.Length;
            }
            _textToFind = textToFind;
            _matchCase = matchCase;
            _matchIndex = forward ? 0 : _matches.Count - 1;
        }
        else
        {
            _matchIndex += forward ? 1 : -1;
            if (_matchIndex < 0)
            {
                _matchIndex = _matches.Count - 1;
            }
            else if (_matchIndex >= _matches.Count)
            {
                _matchIndex = 0;
            }
        }
        if (_matches.Count > 0)
        {
            TheTextBox.SelectionStart = _matches[_matchIndex];
            TheTextBox.SelectionLength = textToFind.Length;
            TheTextBox.Focus();
        }
        else
        {
           MessageBox.Show(string.Format(
               "Could not find '{0}' in the document.", TextToFind),
               ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    public bool FindAndSelectNext(string textToFind, bool matchCase)
    {
        MoveToNextMatch(textToFind, matchCase, true);
    }
    public bool FindAndSelectPrevious(string textToFind, bool matchCase)
    {
        MoveToNextMatch(textToFind, matchCase, false);
    }
