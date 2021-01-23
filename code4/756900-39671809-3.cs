    IncrementCountButton.AttachActionMessage("Click", "IncrementCount", null);
    IncrementCountButton2.AttachActionMessage("Click", "IncrementCount2", 12);
    public void IncrementCount()
    {
        Count++;
    }
    public void IncrementCount2(int value)
    {
        Count += value;
    }
