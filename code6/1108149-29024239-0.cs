        private static void GetSumsRecursively(
            List<int> numbers,
            int sum, 
            List<int> candidates, 
            int numbersCount,
            List<List<int>> results)
        {
            int candidateSum = candidates.Sum(x => x);
            if (candidateSum == sum && candidates.Count == numbersCount)
            {
                results.Add(candidates);
            }
            if (candidateSum >= sum)
                return;
            for (int i = 0; i < numbers.Count; i++)
            {
                var remaining = new List<int>();
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    remaining.Add(numbers[j]);
                }
                var filteredCandidates = new List<int>(candidates) { numbers[i] };
                GetSumsRecursively(remaining, sum, filteredCandidates,
                    numbersCount, results);
            }
        }
        public static List<List<int>> GetNumbers(
            List<int> numbers,
            int numbersCount, 
            int sum)
        {
            if (numbers == null) throw new ArgumentNullException("numbers");
            var results = new List<List<int>>();
            // Fail fast argument validation
            if (numbersCount < 1 ||
                numbersCount > numbers.Count /*||
                sumDifficulty < numQuestions * Question.MinDifficulty ||
                sumDifficulty > numQuestions * Question.MaxDifficulty*/)
            {
                return results;
            }
            // If we only need single questions, no need to do any recursion
            if (numbersCount == 1)
            {
                results.AddRange(numbers.Where(q => q == sum)
                    .Select(q => new List<int> { q }));
                return results;
            }
            // We can remove any questions who have a difficulty that's higher
            // than the sumDifficulty minus the number of questions plus one
            var candidateQuestions =
                numbers.Where(q => q <= sum - numbersCount + 1)
                    .ToList();
            if (!candidateQuestions.Any())
            {
                return results;
            }
            GetSumsRecursively(candidateQuestions, sum, new List<int>(),
                numbersCount, results);
            return results;
        }
