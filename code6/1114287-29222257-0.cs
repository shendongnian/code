    namespace TryOuts
    {
        using System;
        using System.Collections.Generic;
        [Flags]
        public enum PreferedGenres
        {
            None = 0,
            Adventure = 1,
            Romance = 2,
            Police = 4,
            SciFi = 8
        }
        public static class PreferedGenresExtensions
        {
            public static PreferedGenres AddPreference(this PreferedGenres current, PreferedGenres toAdd)
            {
                return current | toAdd;
            }
            public static PreferedGenres RemovePreference(this PreferedGenres current, PreferedGenres toRemove)
            {
                return current & ~(toRemove);
            }
            public static IEnumerable<PreferedGenres> GetSelectedPreferences(this PreferedGenres genres)
            {
                foreach (PreferedGenres g in Enum.GetValues(typeof(PreferedGenres)))
                    if (genres.HasFlag(g) && g != PreferedGenres.None)
                        yield return g;
            }
            public static IEnumerable<PreferedGenres> GetSelectablePrefences(this PreferedGenres genres)
            {
                foreach (PreferedGenres g in Enum.GetValues(typeof(PreferedGenres)))
                    if (!genres.HasFlag(g))
                        yield return g;
            }
        }
        class Program
        {
            public static void Main(params string[] args)
            {
                var myPreferences = PreferedGenres
                    .None
                    .AddPreference(PreferedGenres.SciFi)
                    .AddPreference(PreferedGenres.Adventure);
                Console.WriteLine("My preferences:");
                foreach (var p in myPreferences.GetSelectedPreferences())
                    Console.WriteLine(p);
                Console.WriteLine("Available for selection:");
                foreach (var p in myPreferences.GetSelectablePrefences())
                    Console.WriteLine(p);
                Console.WriteLine("Done");
                Console.ReadLine();
            }
        }
