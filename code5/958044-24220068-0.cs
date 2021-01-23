    DataGridHyperlinkColumn hypCol = new DataGridHyperlinkColumn();
    hypCol.Header = "Link";
    hypCol.ContentBinding = new Binding("PersonName");
    hypCol.Binding = new Binding("PersonID") {
        Converter = new FormatStringConverter(),
        ConverterParameter = "PersonEditPage.xaml?PersonID={0}"
    };
