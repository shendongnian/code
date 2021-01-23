    private class Test
    {
        public int A { get; set; }
        public int B { get; set; }
    }
    
    private AB Invoke<AB>() where AB : new ()
    {
        return new AB();
    }
