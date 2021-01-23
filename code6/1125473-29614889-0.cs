    private Image[] ghost = new Image[1];
    Graphics g = e.Graphics;
    internal void Paint_Ghost(Graphics g)
    {
    g.DrawImage(ghostImage[currentPoistion], xPosition, yPosition, 50, 50);
    }
    public void DrawGhost_LoadRight()
    {  
    ghostImage[0] = Image.FromFile("ghost.png");
    }
    private void startButton_Click(object sender, EventArgs e)
    {
    Paint_Ghost(g);
    }
