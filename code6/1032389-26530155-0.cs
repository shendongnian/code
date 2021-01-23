    int currIndex = 0;
    void printDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        Graphics graphic = e.Graphics;
    
        float fontHeight = font.GetHeight();
    
        int startX = 10;
        int startY = 10;
    
        graphic.DrawString(list[currIndex++].Title, new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
        if(currIndex == list.Count)
        {
            e.HasMorePages = false;
            currIndex = 0;
        } 
        else 
        {
            e.HasMorePages = true;
        }
    }
