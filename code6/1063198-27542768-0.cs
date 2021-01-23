    string columnName = "...";
    if(columnName.Length > 60)
    {
        graphic.DrawString(columnName_part1, new Font("Times New Roman", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY);
        startY += 50;
        graphic.DrawString(columnName_part2, new Font("Times New Roman", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY);
    }
