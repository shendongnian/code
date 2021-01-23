        public string ParseoutGroup(string fullString)
        {
            var matches = Regex.Matches(fullString, @"group\s?=\s?'([^']+)'", RegexOptions.IgnoreCase);
            return matches[0].Groups[1].Captures[0].Value;
        }
        public string[] ParseoutTeamNames(string fullString)
        {
            var teams = new List<string>();
            var matches = Regex.Matches(fullString, @"team\s?in\s?\((\s*'([^']+)',?\s*)+\)", RegexOptions.IgnoreCase);
            foreach (var capture in matches[0].Groups[2].Captures)
            {
                teams.Add(capture.ToString());
            }
            return teams.ToArray();
        }
        [Test]
        public void parser()
        {
            string test = "group = '2843360' and (team in ('team1', 'team2', 'team3'))";
            var group = ParseoutGroup(test);
            Assert.AreEqual("2843360",group);
            var teams = ParseoutTeamNames(test);
            Assert.AreEqual(3, teams.Count());
            Assert.AreEqual("team1", teams[0]);
            Assert.AreEqual("team2", teams[1]);
            Assert.AreEqual("team3", teams[2]);
        }
