    public static bool CountStep(int[] arr)
    {
        // assumes we count in base N for an N sized array
        var maxDigit = arr.Length - 1;
        for (var i = arr.Length - 1; i >= 0; i--)
        {
            if (arr[i] < maxDigit)
            {
                arr[i]++;
                for (var j = i + 1; j < arr.Length; j++)
                {
                    arr[j] = 0;
                }
                return true;
            }
        }
        return false;
    }
