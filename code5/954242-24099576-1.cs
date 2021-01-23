            foreach (var line in this.Lines)
            {
                string entries = string.Concat("'", string.Join("','", line))
                                       .TrimEnd('\'').TrimEnd(','); // remove last ",'" 
                this.Query.Add(string.Format(this.LineTemplate, entries));
            }
