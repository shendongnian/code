            var serviceDependence = new Dictionary<string, List<string>>
            {
                { "A", new List<string> { "A" }},
                { "B", new List<string> { "C", "D" }},
                { "D", new List<string> { "E" }},
                { "E", new List<string> { "F", "Q" }},
                { "F", new List<string> { "D" }},
            };
            var cycles = serviceDependence.FindCycles();
            Debug.WriteLine(JsonConvert.SerializeObject(cycles, Formatting.Indented));
            foreach (var cycle in cycles)
            {
                serviceDependence[cycle[cycle.Count - 2]].Remove(cycle[cycle.Count - 1]);
            }
            Debug.Assert(serviceDependence.FindCycles().Count == 0);
