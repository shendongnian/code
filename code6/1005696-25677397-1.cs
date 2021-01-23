    string nameToModify = "Jim";
    string modifiedName = "John";
    for (int i = 0; i < classList.Length; i++)
    {
        // Remove the StringComparison argument if you want to do case-sensitive comparison
        if (classList[i].Equals(nameToModify, StringComparison.OrdinalIgnoreCase))
        {
            classList[i] = modifiedName;
            // Break if you only want to modify the first one found
            break; 
        }
    }
