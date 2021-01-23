        public static IEnumerable<QuizGroups> GetGroups(string sectorId)
        {
            var QuizDataSource = new QuizDataSource();
            return new[] {_QuizDataSource.AllQuizGroups.FirstOrDefault(x => x.Subtitle == sectorId)};
        }
