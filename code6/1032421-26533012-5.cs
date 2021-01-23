    List<int> found = null;
    private void cb_findAll_Click(object sender, EventArgs e)
    {
        clearHighlights(rtb);
        found = FindAll(rtb, txtSearch.Text, rtb.SelectionStart);
        HighlightAll(rtb, Color.Red, found, txtSearch.Text.Length);
    }
    private void cb_findNext_Click(object sender, EventArgs e)
    {
        int pos = -1;
        for (int f = 0; f < found.Count; f++)
            if (found[f] >= rtb.SelectionStart) { pos = found[f]; break; }
        if (pos >= 0) rtb.Select(pos, txtSearch.Text.Length);
        rtb.ScrollToCaret();
    }
    private void cb_findPrev_Click(object sender, EventArgs e)
    {
        int pos = -1;
        for (int f = 0; f < found.Count; f++)
            if (found[f] >= rtb.SelectionStart) { if (f > 1) pos = found[f - 1]; break; }
        if (pos >= 0) rtb.Select(pos, txtSearch.Text.Length);
        rtb.ScrollToCaret();
    }
    public List<int> FindAll(RichTextBox rtb, string txtToSearch, int searchStart)
    {
        List<int> found = new List<int>();
        if (txtToSearch.Length <= 0) return found;
        int pos= rtb.Find( txtToSearch, searchStart, RichTextBoxFinds.None);
        while (pos >= 0)
        {
            found.Add(pos);
            pos = rtb.Find(txtToSearch, pos + txtToSearch.Length, RichTextBoxFinds.None);
        }
        return found;
    }
    public void HighlightAll(RichTextBox rtb, Color color, List<int> found, int length)
    {
        foreach (int p in found)
        {
            rtb.Select(p, length);
            rtb.SelectionColor = color;
        }
    }
