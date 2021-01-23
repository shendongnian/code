    public static class CssUtils
    {
        /// <summary>
        /// http://dev.w3.org/html5/spec/common-microsyntaxes.html#space-character
        /// </summary>
        private static readonly char[] WhitespaceCharacters = new[] { ' ', '\t', '\n', '\f', '\r' };
        /// <summary>
        /// ToggleAggregator toggles the <paramref name="parsedClass"/> within the <paramref name="current"/> classes.
        /// </summary>
        /// <param name="current">
        /// A <see cref="String"/> of whitespace separated classes.
        /// </param>
        /// <param name="parsedClass">
        /// A class to toggle within the <paramref name="current"/> classes.
        /// </param>
        /// <returns>
        /// The <see cref="String"/> of resultant classes.
        /// </returns>
        private static string ToggleAggregator(string current, string parsedClass)
        {
            return HasClass(current, parsedClass)
                       ? RemoveClass(current, parsedClass)
                       : AddClass(current, parsedClass);
        }
        /// <summary>
        /// AddClass adds the provided <paramref name="classes"/> to the <paramref name="source"/> classes.
        /// </summary>
        /// <param name="source">
        /// A <see cref="String"/> of whitespace separated classes.
        /// </param>
        /// <param name="classes">
        /// A <see cref="String"/> of whitespace separated classes to add to the <paramref name="source"/> classes.
        /// </param>
        /// <returns>
        /// The <see cref="String"/> of merged classes.
        /// </returns>
        public static string AddClass(string source, string classes)
        {
            var sourceClasses = ParseClasses(source);
            var parsedClasses = ParseClasses(classes);
            var mergedClasses =
                sourceClasses
                    .Union(parsedClasses)
                    .ToArray()
                    .Join(" ");
            return mergedClasses;
        }
        /// <summary>
        /// AddClass adds the provided <paramref name="classes"/> to the <paramref name="source"/> classes.
        /// </summary>
        /// <param name="source">
        /// A <see cref="String"/> of whitespace separated classes.
        /// </param>
        /// <param name="classes">
        /// An <see cref="Array.string"/> of classes to add to the <paramref name="source"/> classes.
        /// </param>
        /// <returns>
        /// The <see cref="String"/> of merged classes.
        /// </returns>
        public static string AddClass(string source, params string[] classes)
        {
            return AddClass(source, classes.Join(" "));
        }
        /// <summary>
        /// HasClass checks whether all of the provided <paramref name="classes"/> are contained in the <paramref name="source"/> classes.
        /// </summary>
        /// <param name="source">
        /// A <see cref="String"/> of whitespace separated classes.
        /// </param>
        /// <param name="classes">
        /// A <see cref="String"/> of whitespace separated classes to check in the <paramref name="source"/> classes.
        /// </param>
        /// <returns>
        /// <c>True</c> if all of the <paramref name="classes"/> are contained in the <paramref name="source"/> classes, <c>False</c> otherwise.
        /// </returns>
        public static bool HasClass(string source, string classes)
        {
            if (source.IsEmpty() || classes.IsEmpty()) return false;
            var sourceClasses = ParseClasses(source);
            var parsedClasses = ParseClasses(classes);
            return parsedClasses.Intersect(sourceClasses).Count() == parsedClasses.Count();
        }
        /// <summary>
        /// RemoveClass removes the provided <paramref name="classes"/> from the <paramref name="source"/> classes.
        /// </summary>
        /// <param name="source">
        /// A <see cref="String"/> of whitespace separated classes.
        /// </param>
        /// <param name="classes">
        /// A <see cref="String"/> of whitespace separated classes to remove from the <paramref name="source"/> classes.
        /// </param>
        /// <returns>
        /// The <see cref="String"/> of remaining classes.
        /// </returns>
        public static string RemoveClass(string source, string classes)
        {
            var sourceClasses = ParseClasses(source);
            var parsedClasses = ParseClasses(classes);
            var resultClasses =
                sourceClasses
                    .Except(parsedClasses)
                    .ToArray()
                    .Join(" ");
            return resultClasses;
        }
        /// <summary>
        /// RemoveClass removes the provided <paramref name="classes"/> from the <paramref name="source"/> classes.
        /// </summary>
        /// <param name="source">
        /// A <see cref="String"/> of whitespace separated classes.
        /// </param>
        /// <param name="classes">
        /// An <see cref="Array.string"/> of classes to remove from the <paramref name="source"/> classes.
        /// </param>
        /// <returns>
        /// The <see cref="String"/> of remaining classes.
        /// </returns>
        public static string RemoveClass(string source, params string[] classes)
        {
            return RemoveClass(source, classes.Join(" "));
        }
        /// <summary>
        /// ToggleClass toggles the provided <paramref name="classes"/> within the <paramref name="source"/> classes.
        /// </summary>
        /// <param name="source">
        /// A <see cref="String"/> of whitespace separated classes.
        /// </param>
        /// <param name="classes">
        /// A <see cref="String"/> of whitespace separated classes to toggle within the <paramref name="source"/> classes.
        /// </param>
        /// <returns>
        /// The <see cref="String"/> of resultant classes.
        /// </returns>
        public static string ToggleClass(string source, string classes)
        {
            var parsedClasses = ParseClasses(classes);
            return parsedClasses.Aggregate(source ?? "", ToggleAggregator);
        }
        /// <summary>
        /// ToggleClass toggles the provided <paramref name="classes"/> within the <paramref name="source"/> classes.
        /// </summary>
        /// <param name="source">
        /// A <see cref="String"/> of whitespace separated classes.
        /// </param>
        /// <param name="classes">
        /// An <see cref="Array.string"/> of classes to toggle within the <paramref name="source"/> classes.
        /// </param>
        /// <returns>
        /// The <see cref="String"/> of resultant classes.
        /// </returns>
        public static string ToggleClass(string source, params string[] classes)
        {
            return ToggleClass(source, classes.Join(" "));
        }
        /// <summary>
        /// ToggleClass toggles the provided <paramref name="classes"/> within the <paramref name="source"/> classes dependant on the state of the <paramref name="switch"/>.
        /// </summary>
        /// <param name="source">
        /// A <see cref="String"/> of whitespace separated classes.
        /// </param>
        /// <param name="classes">
        /// A <see cref="String"/> of whitespace separated classes to toggle within the <paramref name="source"/> classes.
        /// </param>
        /// <param name="switch">
        /// When <c>True</c>, the <paramref name="classes"/> will be added to the <paramref name="source"/> classes.
        /// When <c>False</c>, the <paramref name="classes"/> will be removed from the <paramref name="source"/> classes.
        /// </param>
        /// <returns>
        /// The <see cref="String"/> of resultant classes.
        /// </returns>
        public static string ToggleClass(string source, string classes, bool @switch)
        {
            return @switch ? AddClass(source, classes) : RemoveClass(source, classes);
        }
        /// <summary>
        /// ParseClasses splits the provided whitespace separated list of <paramref name="classes"/> into an array of distinct classes.
        /// </summary>
        /// <param name="classes">
        /// A <see cref="String"/> of whitespace separated classes.
        /// </param>
        /// <returns>
        /// A <see cref="Array.string"/> of distinct classes.
        /// </returns>
        public static string[] ParseClasses(string classes)
        {
            return (classes ?? "")
                .Split(WhitespaceCharacters, StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .ToArray();
        }
    }
