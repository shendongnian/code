    desc = Regex.Replace(desc, "(<style.+?</style>)|(<script.+?</script>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    desc = Regex.Replace(desc, "(<img.+?>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    desc = Regex.Replace(desc, "(<o:.+?</o:.+?>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    desc = Regex.Replace(desc, "<!--.+?-->", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    desc = Regex.Replace(desc, "class=.+?>", ">", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    desc = Regex.Replace(desc, "class=.+?\s", " ", RegexOptions.IgnoreCase | RegexOptions.Singleline);
