    foreach (SectionData section  in data.Sections)
    {
        newDirctionary.Add(section.SectionName.ToString(), new List<string());
        foreach (KeyData key in section.Keys)
            newDictionary[section.SectionName.ToString()].Add(key.Value.ToString());
    }
