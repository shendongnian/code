    private void CheckContainer(string containerName)
    {
        var invalidNameMessage = "Container names can contain only letters, numbers, and hyphens and must be lowercase. The name must start with a letter or a number. The name can't contain two consecutive hyphens.";
        var anyInvalidChars = new Regex("[^0-9a-z-]");
        if (anyInvalidChars.IsMatch(containerName))
            throw new ArgumentException(invalidNameMessage);
        var startsWithHyphen = new Regex("$-");
        if (startsWithHyphen.IsMatch(containerName))
            throw new ArgumentException(invalidNameMessage);
        var twoHyphens = new Regex("--");
        if (twoHyphens.IsMatch(containerName))
            throw new ArgumentException(invalidNameMessage);
    }
