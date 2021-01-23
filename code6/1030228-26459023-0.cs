    // For Int32, we cache a range of common values, e.g. [-1,4).
    else if (typeof(TResult) == typeof(Int32))
    {
        // Compare to constants to avoid static field access if outside of cached range.
        // We compare to the upper bound first, as we're more likely to cache miss on the upper side than on the 
        // lower side, due to positive values being more common than negative as return values.
        Int32 value = (Int32)(object)result;
        if (value < AsyncTaskCache.EXCLUSIVE_INT32_MAX &&
            value >= AsyncTaskCache.INCLUSIVE_INT32_MIN)
        {
            Task<Int32> task = AsyncTaskCache.Int32Tasks[value - AsyncTaskCache.INCLUSIVE_INT32_MIN];
            return JitHelpers.UnsafeCast<Task<TResult>>(task); // UnsafeCast avoids a type check we know will succeed
        }
    }
