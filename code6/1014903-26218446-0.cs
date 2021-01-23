    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace SubstitutionsWithBudget
    {
        [TestClass]
        public class SubstitutionTest
        {
            private static readonly List<Substitution> Substitutions = new List<Substitution>
                {
                    new Substitution("1", "3", 0.2m),
                    new Substitution("234", "43", 0.3m),
                    new Substitution("5", "2", 0.4m)
                };
    
            private readonly SubstitutionsDefinition substitutionsDefinition = new SubstitutionsDefinition(Substitutions);
    
            [TestMethod]
            public void OriginalQuestion()
            {
                string source = "12345";
    
                var variants = EnumerateSubstitutions(new Context(), substitutionsDefinition, source, 0.6m);
    
                foreach (var variant in variants)
                {
                    Console.WriteLine(variant);
                }
    
                Assert.AreEqual(5, variants.Count());
            }
    
            [TestMethod]
            public void MultiplicityTest()
            {
                const int multiplicity = 6;
                string source = string.Join("", Enumerable.Repeat("12345", multiplicity));
    
                var variants = EnumerateSubstitutions(new Context(), substitutionsDefinition, source, multiplicity * 0.6m).ToList();
    
                foreach (var variant in variants.Take(10))
                {
                    Console.WriteLine(variant);
                }
            }
    
            [TestMethod]
            public void SomeUsefulApplication()
            {
                var substitutions = new List<Substitution>
                {
                    new Substitution("monkey", "elephant", 2m),
                    new Substitution("monkey", "shark", 3m),
                    new Substitution("banana", "apple", 1m),
                    new Substitution("feed", "kill", 4m),
                };
                var resultingSubstitutions = EnumerateSubstitutions(
                    new Context(),
                    new SubstitutionsDefinition(substitutions),
                    "feed monkey with banana",
                    4)
                    .OrderBy(s => s.Item2).ToList();
                foreach (var substitution in resultingSubstitutions)
                {
                    Console.WriteLine(substitution);
                }
    
                Assert.IsTrue(resultingSubstitutions.Any(
                    s => s.Item1 == "feed elephant with banana"));
                Assert.IsFalse(resultingSubstitutions.Any(
                    s => s.Item1 == "kill shark with banana"));
            }
    
            IEnumerable<Tuple<string, decimal>> EnumerateSubstitutions(Context context, SubstitutionsDefinition substitutionsDefinition, string source, decimal maxCost)
            {
                if (source.Length == 0)
                {
                    yield break;
                }
                var possibleSubstitutions = substitutionsDefinition.GetSubstitutions(source, maxCost).ToList();
    
                // find substitutions of whole string
                foreach (var possibleSubstitution in possibleSubstitutions)
                {
                    yield return Tuple.Create(possibleSubstitution.Destination, possibleSubstitution.Weight);
                }
    
                // Variable split boundary to accomodate tokens of different length
                var middle = source.Length / 2;
                var window = substitutionsDefinition.MaxLength - 1;
    
                if (window > source.Length - 2)
                {
                    window = source.Length - 2;
                }
                var min = middle - window / 2;
    
                var returned = new HashSet<Tuple<string, decimal>> { Tuple.Create(source, 0m) };
    
                for (var i = 0; i <= window; i++)
                {
                    var divideAt = min + i;
                    var left = source.Substring(0, divideAt);
                    var right = source.Substring(divideAt, source.Length - divideAt);
                    var q =
                        from leftSubstitution in context.GetCachedResult(Tuple.Create(left, maxCost),
                            () => EnumerateSubstitutions(context, substitutionsDefinition, left, maxCost)).Concat(new[] { Tuple.Create(left, 0m) })
                        let leftCost = leftSubstitution.Item2
                        from rightSubstitution in context.GetCachedResult(Tuple.Create(right, maxCost - leftCost),
                        () => EnumerateSubstitutions(context, substitutionsDefinition, right, maxCost - leftCost)).Concat(new[] { Tuple.Create(right, 0m) })
                        where leftCost + rightSubstitution.Item2 <= maxCost
                        select new { leftSubstitution, rightSubstitution };
                    q = q.ToList();
    
                    foreach (var item in q.Select(pair => Tuple.Create(pair.leftSubstitution.Item1 + pair.rightSubstitution.Item1,
                        pair.leftSubstitution.Item2 + pair.rightSubstitution.Item2)).Where(item => !returned.Contains(item)))
                    {
                        yield return item;
                        returned.Add(item);
                    }
                }
            }
        }
        public struct Substitution
        {
            public readonly string Souce;
            public readonly string Destination;
            public readonly decimal Weight;
    
            public Substitution(string souce, string destination, decimal weight)
            {
                Souce = souce;
                Destination = destination;
                Weight = weight;
            }
        }
    
        public class Context
        {
            private readonly Dictionary<Tuple<string, decimal>, List<Tuple<string, decimal>>> cache = new Dictionary<Tuple<string, decimal>, List<Tuple<string, decimal>>>();
    
            public IEnumerable<Tuple<string, decimal>> GetCachedResult(Tuple<string, decimal> key, Func<IEnumerable<Tuple<string, decimal>>> create)
            {
                List<Tuple<string, decimal>> result;
                cache.TryGetValue(key, out result);
                if (result != null) return result;
                result = create().ToList();
                cache.Add(key, result);
                return result;
            }
    
            public void AddToCache(Tuple<string, decimal> key, List<Tuple<string, decimal>> result)
            {
                cache.Add(key, result);
            }
        }
    
        public class SubstitutionsDefinition
        {
            private readonly decimal maxCost;
            private const int Granularity = 10;
    
            /// <summary>
            /// Holds substitutions lookups based on budget slots.
            /// A slot with higher budget also holds values of all lower-budget slots.
            /// </summary>
            private readonly ILookup<int, ILookup<string, Substitution>> byCost;
    
            private readonly int maxLength;
    
            private readonly ILookup<string, Substitution> simple;
    
            private bool simpleMode;
    
            public int MaxLength { get { return maxLength; } }
    
            // Really helpful if there are a lot of substitutions
            public IEnumerable<Substitution> GetSubstitutions(string token, decimal budget)
            {
                return simpleMode
                    ? GetSubstitutionsSmallSet(token, budget)
                    : GetSubstitutionsLargeSet(token, budget);
            }
    
            private IEnumerable<Substitution> GetSubstitutionsLargeSet(string token, decimal budget)
            {
                return byCost[GetSlot(budget)].SelectMany(i => i[token]).Where(s => s.Weight <= budget);
            }
    
            public IEnumerable<Substitution> GetSubstitutionsSmallSet(string token, decimal budget)
            {
                return simple[token].Where(s => s.Weight <= budget);
            }
    
            public SubstitutionsDefinition(IEnumerable<Substitution> substitutions)
            {
                var list = substitutions.ToList();
                simpleMode = list.Count < 20; // Need to be found experimentally.
                simple = list.ToLookup(i => i.Souce);
                maxCost = list.Max(s => s.Weight);
                maxLength = list.Max(s => s.Souce.Length);
                var byLength = list.ToLookup(s => s.Souce.Length);
                var q =
                    from length in list.Select(i => i.Souce.Length).Distinct()
                    from budgetSlot in Enumerable.Range(0, Granularity + 1)
                    from item in byLength[length]
                    where item.Weight <= GetCost(budgetSlot)
                    group item by budgetSlot;
                byCost = q.ToLookup(i => i.Key, i => i.ToLookup(j => j.Souce));
            }
    
            private decimal GetCost(int slot)
            {
                var d = maxCost * slot;
                return d / Granularity;
            }
    
            private int GetSlot(decimal weight)
            {
                var maxWeight = Math.Min(weight, maxCost);
                return (int)(Granularity * maxWeight / maxCost);
            }
        }
    }
