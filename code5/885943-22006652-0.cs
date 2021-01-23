    float totalSame = 0F, percentSame = 0F, totalElements = 0F;
    foreach (var previouslyStoredArray in ArrayOfArrays)
    {
        var lockObject = new Object();
        Parallel.For(0, //min index
                     Math.Min(ArrayToBeCompared.Length, previouslyStoredArray.Length), //max index
                     () => 0F, //Initial thread local sameness value
                     (arrayIndex, loopState, localSameness) =>
                     {
                         if (ArrayToBeCompared[arrayIndex] == previouslyStoredArray[arrayIndex])
                             localSameness++;
                         return localSameness;
                     },
                     (localSameness) => 
                     {
                         //This function is not thread safe so we must lock while we aggregate the local counts.
                         lock(lockObject)
                         {
                             totalSame += localSameness;
                         }
                     });
    }
    totalElements = ArrayToBeCompared.Length * ArrayOfArrays.Length;                            
    //By taking the total number of similar elements and dividing by the total
    //number of elements we can get the percentage that are similar
    percentSame = totalSame / totalElements * 100F;
