    private void RemoveSuperfluousSpaces(string filename)
    {
        bool superfluousSpacesFound = true;
        using (DocX document = DocX.Load(filename))
        {
            List<int> multipleSpacesLocs;
            while (superfluousSpacesFound)
            {
                document.ReplaceText("  ", " ");
                multipleSpacesLocs = document.FindAll("  ");
                superfluousSpacesFound = multipleSpacesLocs.Count > 0;
            }
            document.Save();
        }
    }
