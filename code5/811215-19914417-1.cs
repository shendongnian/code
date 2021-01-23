         public double? End // has to be nullable double to return null on last item
         { 
           get 
           { 
               var nDx = Collection.IndexOf(this);
               return Collection.Count > nDx+1?  Collection[nDx + 1].Start: (double?)null;
           }
         }
