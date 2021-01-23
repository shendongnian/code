            var query = from xe in xdoc.Descendants(w + "p")
                        let replacement = xe
                            .Descendants(w + "r").Descendants(w + "t")
                            .Where(xt => xt.Value.StartsWith("AUTOREPLACE"))
                            .Select(xt => new ImagePageCreation("0080275B", "0080275B", "0080275B").GetFullElement())
                            .FirstOrDefault()
                        where replacement != null
                        select new { Original = xe, Replacement = replacement };
            foreach (var pair in query.ToList())
            {
                pair.Original.ReplaceWith(pair.Replacement);
            }
