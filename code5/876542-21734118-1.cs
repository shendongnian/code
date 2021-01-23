        var s = "My. name. is Bond._James Bond!";
        var firstSplit = true;
        var splitChar = '_';
        var splitStrings = s.Split(new[] { splitChar }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x =>
            {
                if (!firstSplit)
                {
                    return splitChar + x;
                }
                firstSplit = false;
                return x;
            });
