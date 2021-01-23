    for (int n = glossarywords.Items.Count - 1; n >= 0; --n)
    {
        if (glossarywords.Items[n].ToString().Contains("the "))
        {
            glossarywords.Items.RemoveAt(n);
        }
        else if (glossarywords.Items[n].ToString().Contains("an"))
        {
            glossarywords.Items.RemoveAt(n);
        }
        else if (glossarywords.Items[n].ToString().Contains(" the"))
        {
            glossarywords.Items.RemoveAt(n);
        }
    }
