    var movie = new Movie() { ... };
    foreach (var prop in typeof(Movie).GetProperties())
    {
        if (prop.PropertyType.IsGenericType && 
            prop.PropertyType.GetGenericTypeDefinition() == typeof (List<>))
        {
            /* Get the generic type parameter of the List<> we're working with: */
            Type genericArg = prop.PropertyType.GetGenericArguments()[0];
            
            /* If this is a List of something derived from IMedia: */
            if (typeof(IMedia).IsAssignableFrom(genericArg))
            {
                var enumerable = (IEnumerable)prop.GetValue(movie);
                List<IMedia> media = 
                    enumerable != null ? 
                    enumerable.Cast<IMedia>().ToList() : null;
                
                // where DoSomething takes a List<IMedia>
                DoSomething(media);
            }
        }
    }
