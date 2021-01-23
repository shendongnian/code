    var doc = new Document();
    var page = new Page(doc);
    page.Title = new Title(doc)
    {
        TitleText = new RichText(doc)
                        {
                            Text = "Title text.",
                            DefaultStyle = TextStyle.DefaultMsOneNoteTitleTextStyle
                        },
        TitleDate = new RichText(doc)
                        {
                            Text = new DateTime(2011, 11, 11).ToString("D", CultureInfo.InvariantCulture),
                            DefaultStyle = TextStyle.DefaultMsOneNoteTitleDateStyle
                        },
        TitleTime = new RichText(doc)
                        {
                            Text = "12:34",
                            DefaultStyle = TextStyle.DefaultMsOneNoteTitleTimeStyle
                        }
    };
    page.AppendChild(outline);
    doc.AppendChild(page);
    doc.Save("output.one")
