        private void button4_Click(object sender, EventArgs e)
        {
            IEnumerable<Journal> sortedJournals = GetJournals(@"c:\temp\test.txt");
            //now you can loop through sortedJournals
            //or you can create groups of journals
            var journalByDatabase = sortedJournals.ToLookup(j => j.Database);
            foreach (var group in journalByDatabase)
            {
                foreach (var item in group)
                {
                }
            }
        }
        public IEnumerable<Journal> GetJournals(string JournalsPath)
        {
            
            var myJournals =
                from c in
                    (
                        from line in File.ReadAllLines(JournalsPath).Skip(1)
                        let aRecord = line.Split(',')
                        select new Journal()
                        {
                            LineNo = Convert.ToInt32(aRecord[0].Trim()),
                            Database = aRecord[1].Trim(),
                            Date = Convert.ToDateTime(aRecord[2].Trim()),
                            Amount = Convert.ToDecimal(aRecord[3].Trim()),
                        }
                    ).OrderBy(x => x.Database)
                select c;
            return myJournals;
        }
