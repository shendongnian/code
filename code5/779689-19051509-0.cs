    Panel panelArray = new Panel[];
    Panel panel2 = panelArray[0];
    
    
    for (int i = 0; i <= 100; i++)
    {
        panel2.Location = new Point(panel2.Location.X - i, panel2.Location.Y);
        System.Threading.Thread.Sleep(10);
    }
