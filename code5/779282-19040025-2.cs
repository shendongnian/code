        var originalContent = System.IO.File.ReadAllText(originalFile);
        var replacements = System.IO.File.ReadAllLines(replacementsFile);
        foreach(var replacement in replacements)
        {
            var _split = replacement.Split(new char[] { '^' });
            originalContent = originalContent.Replace(_split[1], _split[2]);
        }
        System.IO.File.WriteAllText(originalFile, originalContent);
    }
