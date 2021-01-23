    rng.Find.ClearFormatting();
    rng.Find.Forward = false;
    rng.Find.Text = value;
    while (rng.Find.Execute())
    {
         rng.Document.Hyperlinks.Add(rng, rng.Document.Name, CorrespondingBookmark(rng.Text));
         rng.Find.Execute();
    }
