      public static class LinqExtentions
      {        
        // Extension method 1 : Just to change the message for the "more than one" exception
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, string moreThanOneMatchMessage = "MoreThanOneMatch")
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            IList<TSource> list = source as IList<TSource>;
            if (list != null)
            {
                switch (list.Count)
                {
                    case 0:
                        return default(TSource);
                    case 1:
                        return list[0];
                }
            }
            else
            {
                using (IEnumerator<TSource> enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        return default(TSource);
                    }
                    TSource current = enumerator.Current;
                    if (!enumerator.MoveNext())
                    {
                        return current;
                    }
                }
            }
            // I Changed this line below from their code - moreThanOneMatchMessage as parameter
            // It was : throw Error.MoreThanOneElement(); in other words it was throw new InvalidOperationException("MoreThanOneMatch");
            throw new InvalidOperationException(moreThanOneMatchMessage);
        }
        // Extension method 2 : Change the Exception Type to be thrown and the message
        public static TSource SingleOrDefault<TSource, TMoreThanOnceExceptionType>(this IEnumerable<TSource> source, string noElementsMessage = "NoElements", string moreThanOneMatchMessage = "MoreThanOneMatch")
           where TMoreThanOnceExceptionType : Exception
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            IList<TSource> list = source as IList<TSource>;
            if (list != null)
            {
                switch (list.Count)
                {
                    case 0:
                        return default(TSource);
                    case 1:
                        return list[0];
                }
            }
            else
            {
                using (IEnumerator<TSource> enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        return default(TSource);
                    }
                    TSource current = enumerator.Current;
                    if (!enumerator.MoveNext())
                    {
                        return current;
                    }
                }
            }
            // Changes this line below to throw dynamic exception type.
            // It was : throw Error.MoreThanOneElement(); in other words it was throw new InvalidOperationException("MoreThanOneMatch");
            // Yes some believe the Activator can slow down code, If you use a DI Framework and register your exception type this should not be the case
            throw (TMoreThanOnceExceptionType)Activator.CreateInstance(typeof(TMoreThanOnceExceptionType), moreThanOneMatchMessage);
        }
    }
