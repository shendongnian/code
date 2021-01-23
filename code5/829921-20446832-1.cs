    Regex regex = new Regex(@"^(?:100|[1-9][0-9]?|0)(?:\.[0-9]?[1-9])?%$", RegexOptions.Compiled);
    for (int l = 0; l < resplitted.Length; l++) {
        Match match = regex.Match(resplitted[l]);
        if (match.Success) {
            bsc =double.Parse(match.Value);
            MessageBox.Show(bsc.ToString());
        }
    }
