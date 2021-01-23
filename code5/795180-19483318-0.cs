            var r = new System.Text.RegularExpressions.Regex(@"(?<Num>[+-]+[\d]+.[\d]+)");
            foreach (var g in foo) {
                var st = g.First();
                var mt = r.Matches(st);
                var sums = new double[mt.Count];
                foreach (var l in g) {
                    var m = r.Matches(l);
                    for (var i = 0; i < m.Count; i++) {
                        double d;
                        if (double.TryParse(m[i].Value, out d)) {
                            sums[i] += d;
                            }
                        }
                    }
                var sb = new StringBuilder();
                var start = 0;
                for (var i = 0; i < mt.Count; i++) {
                    sb.Append(st.Substring(start, mt[i].Index - start));
                    if (sums[i] >= 0.0) { sb.Append("+"); }
                    else                { sb.Append("-"); }
                    sb.Append(sums[i]);
                    start = mt[i].Index + mt[i].Length;
                    }
                sb.AppendLine(st.Substring(start));
                Console.Write(sb.ToString());
                }
 
