            var entries = new List<DataEntry>()
            {
                new DataEntry(0, 1.4),
                new DataEntry(500, 1.3),
                new DataEntry(1000, 1.2),
                new DataEntry(1500, 1.5),
                new DataEntry(2000, 1.3),
                new DataEntry(2500, 1.3),
                new DataEntry(3000, 1.2),
                new DataEntry(3500, 1.3)
            };
            double totalTime = entries
                .OrderBy(e => e.Time)
                .Take(entries.Count - 1)
                .Where((t, i) => t.Reading >= 1.3 && entries[i + 1].Reading >= 1.3)
                .Sum(t => 500);
            var perct = (totalTime / entries.Last().Time);
