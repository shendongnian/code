    public static class EnumerationExtensions {
    public static IEnumerable<IEnumerable<T>> SplitIntoGroupsOfSize<T>(IEnumerable<T> collection, int ofSize) {
    	for(
    		IEnumerable<T> remainingCollection = collection; 
    		remainingCollection.Count() > 0; 
    		remainingCollection = remainingCollection.Skip(ofSize) ) {
    			yield return remainingCollection.Take(ofSize);
    		}
    }
    }
    var collection = Enumerable.Range(1, 22).ToArray();
    var groups = EnumerationExtensions.SplitIntoGroupsOfSize(collection, ofSize: 4);
    var res = String.Join("\n-------------\n", groups.Select(g => String.Join(", ", g) ) );
    Console.WriteLine(res);
