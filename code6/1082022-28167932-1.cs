    regex.Replace(textContent, delegate(Match m) {
        int id = -1, newId;
        if (Int32.TryParse(m.Groups["RefId"].Value, out id)) {
            if (idDictionary.TryGetValue(id, out newId)) {
                return newId.ToString();
            }
            return m.Value; // if TryGetValue fails, return the match
        }
    });
