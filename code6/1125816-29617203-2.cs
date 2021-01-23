            XNamespace w = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
            var query = from xe in xdoc.Descendants(w + "p")
                        let replacement = xe
                            .Descendants(w + "r").Descendants(w + "t")
                            .Where(xt => xt.Value.StartsWith("AUTOREPLACE"))
                            .Select(xt => new ImagePageCreation("0080275B", "0080275B", "0080275B").GetFullElement())
                            .ToList()
                        where replacement.Count > 0
                        select new { Original = xe, ReplacementList = replacement };
            foreach (var pair in query.ToList())
            {
                pair.Original.ReplaceWith(pair.ReplacementList);
            }
