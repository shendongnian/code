    if (fontFamilies[i].IsStyleAvailable(FontStyle.Regular)) familyList[i].Font = new Font(fontFamilies[i], 12);
    else if (fontFamilies[i].IsStyleAvailable(FontStyle.Bold)) familyList[i].Font = new Font(fontFamilies[i], 12, FontStyle.Bold);
    else if (fontFamilies[i].IsStyleAvailable(FontStyle.Italic)) familyList[i].Font = new Font(fontFamilies[i], 12, FontStyle.Italic);
    else if (fontFamilies[i].IsStyleAvailable(FontStyle.Strikeout)) familyList[i].Font = new Font(fontFamilies[i], 12, FontStyle.Strikeout);
    else if (fontFamilies[i].IsStyleAvailable(FontStyle.Underline)) familyList[i].Font = new Font(fontFamilies[i], 12, FontStyle.Underline);
    else familyList[i].BackColor = Color.Red;
