    checked // ensures that values outside of byte's range do not fail silently
    {
        var output = new int[] { 10, 135, 3, 10, 182 };
        var binary = output.Select(x => (byte)x)
               .Concat("Hello, world".Select(c => (byte)c)).ToArray();
        
        var result = Convert.ToBase64String(binary);
    }
