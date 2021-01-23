    for (int iRow = 0; iRow < numBlocks; iRow++)
    {
        for (int iColumn = 0; iColumn < numBlocks; iColumn++)
        {
            Panel p = new Panel();
            // set size, position, etc, then:
        
            p.MouseEnter += (s,e) => { (s as Panel).BackColor=Color.Red; }
            p.MouseLeave += (s,e) => { (s as Panel).BackColor=Color.Black; }
            // the panel is born of this color
            p.BackColor = Color.Black; // .. or any color you put in MouseLeave
            groupBox1.Controls.Add(p);  
        }
    }
