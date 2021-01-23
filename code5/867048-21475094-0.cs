    public struct mark
    {
        public int value { get; set; }
    }
    
    student x = new student();
    x.id = 1;
    x.mark.value = 5; // No exception thrown
