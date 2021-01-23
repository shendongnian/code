    DateTime result;
    bool canParse = DateTime.TryParseExact(this.TxtCompanyFounded.Text,
        "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
    if (canParse)
    {
        myCompanyAccount.Founded = result;
    }
    else
    {
        // take care of problematic input
    }
