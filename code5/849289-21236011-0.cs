        private List<List<decimal>> FindBestMatches(List<decimal> numbersOrdered)
        {
            var resultList = new List<List<decimal>>();
            if (numbersOrdered.Sum() < 10)
            {
                return resultList;
            }
            var possibleSumsWithinRange = GetPowerSet(numbersOrdered).Select(combination => combination.Sum()).Distinct().Where(sum => sum>= 10 && sum < 20).OrderBy(sum => sum);
            //Remove highest sum if there are more than one possible sum
            if (possibleSumsWithinRange.Count() > 1)
            {
                possibleSumsWithinRange.ToList().RemoveAt(possibleSumsWithinRange.Count() - 1);   
            }
            //Go through all possible sums in order to find best result (lowest highest sum)
            foreach (var possibleSum in possibleSumsWithinRange)
            {
                //Console.WriteLine("Sum:" + possibleSum);
                var subResultList = new List<List<decimal>>();
                var numbers = numbersOrdered.ToList();
                while (true)
                {
                    var combinations = GetPowerSet(numbers);
                    var bestMatch = new List<decimal>();
                    foreach (var combination in combinations)
                    {
                        decimal sum = combination.Sum();
                        if (sum < possibleSum)
                        {
                            continue;
                        }
                        if (sum == possibleSum) //Found perfect match - use this combination
                        {
                            bestMatch = combination.ToList();
                            break;
                        }
                        else if (sum > possibleSum && (!bestMatch.Any() || sum < bestMatch.Sum()))
                        {
                            bestMatch = combination.ToList();
                        }
                    }
                    //If we found a valid solution, remove these values from the ordered list and use same approach on the remaining values
                    if (bestMatch.Any())
                    {
                        bestMatch.ForEach(item => numbers.Remove(item));
                        subResultList.Add(bestMatch.ToList());
                        continue;
                    }
                    //If the new solution is the first or better than the previous, then promote it to result
                    if (!resultList.Any() || IsBetterSolution(resultList, subResultList))
                    {
                        resultList = subResultList.ToList();
                    }
                    break;
                }
            }
            return resultList;
        }
        public bool IsBetterSolution(List<List<decimal>> previousSolution, List<List<decimal>> newSolution)
        {
            //If the new solution has more pools than the previous, then it is considered better
            if (newSolution.Count > previousSolution.Count)
            {
                return true;
            }
            //If they have the same amount of pools, then choose the solution with the lowest highest sum
            return (newSolution.Count == previousSolution.Count) && (highestSum(newSolution) < highestSum(previousSolution));
        }
        public decimal highestSum(List<List<decimal>> solution)
        {
            return solution.Max(x => x.Sum());
        }
        public IEnumerable<IEnumerable<T>> GetPowerSet<T>(List<T> list)
        {
            return from m in Enumerable.Range(0, 1 << list.Count)
                   select
                       from i in Enumerable.Range(0, list.Count)
                       where (m & (1 << i)) != 0
                       select list[i];
        }
