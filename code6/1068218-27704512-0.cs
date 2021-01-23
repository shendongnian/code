    private string  concatArticle()
    {
        string libArt = string.Join(", ", ListeArt.Rows.OfType<DataGridViewRow>()
                       .Select(i => i.Cells["yourColumnName"].Value.ToString()).ToArray());
        return libArt;
    }
