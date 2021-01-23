    TitelDataType titel = new TitelDataType();
    int id = 1;
    if (Titelslijst.Count > 0)
    {
        var titles = Titelslijst.Where(t => t.ID_Artiest == itemDezeWeek.ID_Artiest);
        if (titles.Any())
            id = titles.Max(t => t.ID_Titel) + 1;
    }
    titel.ID_Titel = id;
