        public static IEnumerable<QuizGroups> GetGroups(string sectorId)
        {
            return new[]
            {
                _QuizDataSource.AllQuizGroups.FirstOrDefault(x => x.Subtitle == sectorId)
            };
        }
