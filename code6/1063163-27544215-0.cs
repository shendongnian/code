    // I am just using German Number representations for the example.
    // Replaye with whatever suits your needs.
    string[] monthNames =
        {
          "Eins",
          "Zwei",
          "Drei",
          "Vier",
          "Fünf",
          "Sechs",
          "Sieben",
          "Acht",
          "Neun",
          "Zehn",
          "Elf",
          "Zwölf",
          string.Empty
        };
      ci.DateTimeFormat.MonthNames = monthNames;
      ci.DateTimeFormat.MonthGenitiveNames = monthNames;
      ci.DateTimeFormat.AbbreviatedMonthNames = monthNames;
      ci.DateTimeFormat.AbbreviatedMonthGenitiveNames = monthNames;
