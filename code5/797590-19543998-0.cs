    DateTime toCompare = new DateTime(2013, 10, 23, 15, 43, 56);
    string fileImageName = "Picture_MIGA1_2013_10_23_15_43_56.png";
    DateTime dt;
    DateTime.TryParseExact(
        Path.GetFileNameWithoutExtension(fileImageName),
        "yyyy_MM_dd_HH_mm_ss",
        CultureInfo.InvariantCulture,
        DateTimeStyles.None,
        out dt);
    bool isSame = toCompare == dt;
