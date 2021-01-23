    private static void Main()
    {
        string ido = "433, 045, 3-3-15, 444, 0.6,3.9,4,5,5,4,3,3";
        // Split on both comma and dash
        var items = ido.Split(',', '-');
        // This list will hold all the items converted to floats
        var result = new List<float>();
        foreach (var item in items)
        {
            float temp;
            // Use TryParse to ensure we can successfully convert each item
            if (float.TryParse(item, out temp))
            {
                result.Add(temp);
            }
        }
        // Display final results
        Console.WriteLine(string.Join(", ", result));
    }
