            IDictionary<ClassificationLevel, Int32> dict = context.Exams
                .GroupBy(x => x.Classification)
                .Select(x => new { Key = x.Key, Count = x.Count() })
                .AsEnumerable()
                .ToDictionary(g => g.Key, g => g.Count);
            foreach (ClassificationLevel level in Enum.GetValues(typeof(ClassificationLevel)))
                if (!dict.ContainsKey(level))
                    dict[level] = 0;
