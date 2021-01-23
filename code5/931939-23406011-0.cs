    PictureBox[,] cell = new PictureBox[,] {
        { cell1, cell2, cell3 },
        { cell4, cell5, cell6 },
        { cell7, cell8, cell9 }
    };
    
    string[,] c = new string[3, 3];
    for(int y=0; y<3; y++)
        for(int x=0; x<3; x++)
            c[x, y] = cell[x, y].BackColor.ToString();
