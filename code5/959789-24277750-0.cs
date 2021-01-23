            List<string> _terms = new List<string>();
            List<string> _wins = new List<string>();
            _terms.Add("Australia");
            _wins.Add("5");
            using (var e1 = _terms.GetEnumerator())
            using (var e2 = _wins.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext())
                {
                    var item1 = e1.Current;
                    var item2 = e2.Current;
                    // use item1 and item2
                }
            }
