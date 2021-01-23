       var props = new PageRatingList(); /*actual instanse of the object, in your case, i think "props.Value" */
       var properties = typeof(PageRatingList).GetProperties();
       foreach (var property in properties)
       {
           if (property.PropertyType == typeof(IList<PageRating>))
           {
               IList<PageRating> list  = (IList<PageRating>)property.GetValue(props);
                    
               /* do */
           }
           else
           {
                object val = property.GetValue(props);
           }
        }
