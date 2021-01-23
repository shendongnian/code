    public void NudgeWindow(Window window)
    {
    var originalLeft = (int) Left;
    var originalTop = (int) Top;
    var rnd = 0;
    var RandomClass = new Random();
    for (int i = 0; i <= 500; i++)
    {
        rnd = RandomClass.Next(originalLeft + 1, originalLeft + 15);
        Left = rnd;
        rnd = RandomClass.Next(originalTop + 1, originalTop + 15);
        Top = rnd;
    }
    Left = originalLeft;
    Top = originalTop;
}
