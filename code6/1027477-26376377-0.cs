    // Get the default formatted date
    string indonesianDate =  suratKeluarc.TglSurat.ToString();
    // Parse the date string using the indonesian cultureinfo
    System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("id-ID");
    DateTime dt = DateTime.Parse(indonesianDate, cultureinfo);
    // Get your formatted string.
    lblTglSuratKeluar.Text = dt.ToString("dd MMMM yyyy", cultureinfo);
