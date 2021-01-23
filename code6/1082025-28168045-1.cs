    var updatedContent =  regex.Replace(textContent, match =>
        {
            var id = -1;
            if (Int32.TryParse(match.Groups["RefId"].Value, out id))
            {
                int newId;
                // idDictionary contains the mapping from old id to new id
                if (idDictionary.TryGetValue(id, out newId))
                {
                    // Now replace the id of the current match with the new id
                    return newId.ToString();
                }
            }
            // No change
            return match.Value;
        });
