        private Int32 GetHighest(Int32 y, out Int32 B)
        {
            var Set = new Int32[] { 4, 3, 2 };
            var Totals = new List<Int32>();
            foreach (var x in Set)
            {
               Double DResuslt = y/x;
               Int32 Result = Convert.ToInt32(Math.Floor(DResuslt));
               Totals.Add(x * Result);
            }
            var Max = Totals.Max();
            var Maxs = Totals.Select((total, index) => new {T = total, index})
                        .Where(r=> r.T == Max).ToList();
            var Maximum = Maxs.Select(G => Set[G.index]).Max();
            B = Totals[Array.IndexOf(Set, Maximum)];
            return Maximum;
        }
