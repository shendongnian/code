    private Rectangle[] brickRec;
    
    public Brick()
    {
        brickLength = 60;
        brickHeight = 20;
        int[,] brickLocation = { { 0, 0 }, { 62, 0 }, { 123, 0 }, { 184, 0 }, { 245, 0 }, { 306, 0 }, { 367, 0 } };
        bool[] brickLive = { true, true, true, true, true, true, true };
    
        brickImage = Breakout.Properties.Resources.brick_fw;
    
        brickRec = new Rectangle[brickLocation.GetLength(0)];
        for (int i = 0; i < brickLocation.GetLength(0); i++)
        {
            brickRec[i] = new Rectangle(brickLocation[i, 0], brickLocation[i, 1], brickLength, brickHeight);
        }
    }
    
    
    public void drawBrick(Graphics paper)
    {
        for (int i = 0; i < brickRec.Length; i++) {
            paper.DrawImage(brickImage, brickRec[i]);
        }
    }
