    namespace Raven.Client.Linq
    {
        public static class RavenQueryableExtensions
        {
            // Summary:
            //     Implementation of the Contains ALL operatior
            public static bool ContainsAll<T>(this IEnumerable<T> list, IEnumerable<T> items);
        }
    }
