    public static int ClosestIndexOf(this string input, string value, int startIndex)
    {
        // get closest index below and above specified "startIndex" position
        int above = input.IndexOf(value, startIndex);
        int below = input.LastIndexOf(value, startIndex - 1);
        
        int middle = (below + above) / 2;
        
        int result;
        if (middle > startIndex)
            result = below;
        else
            // use MAX in case above == -1
            result = Math.Max(above, below);
        
        return result;
    }
