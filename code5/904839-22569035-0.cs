    string dateTakenText;
    using (Image photo = Image.FromFile(file.Name))
    {
        PropertyItem pi = photo.GetPropertyItem(Program.propertyTagExifDTOrig_);
        ASCIIEncoding enc = new ASCIIEncoding();
        dateTakenText = enc.GetString(pi.Value, 0, pi.Len - 1);
    }
    if (string.IsNullOrEmpty(dateTakenText))
    {
        continue;
    }
    DateTime dateTaken;
    if (!DateTime.TryParseExact(dateTakenText, "yyyy:MM:dd HH:mm:ss",
        CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTaken))
    {
        continue;
    }
