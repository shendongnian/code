    public List<decimal> Allocate(decimal input, int items, int precision)
    {
       decimal split = Math.Round((input / items), precision);
       List<decimal> output = Enumerable.Repeat(split, items).ToList();
       
       decimal remainder = input - output.Sum();
       output[output.Count - 1] += remainder;
       
       return output;
    }
