    //Five Values at class level
    int[] myPiePercent = { 10, 20, 25, 5, 40 };
    //Take Colors To Display Pie In That Colors Of Taken Five Values.
    Color[] myPieColors = { Color.Red, Color.Black, Color.Blue, Color.Green, Color.Maroon };
    public void DrawPieChart()
    {
        // maybe change the values here..
        myPiePercent = { 11, 22, 23, 15, 29 };
        // then let Paint call the draw routine:
        panel1.Invalidate();
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    
       //Give Location Which Will Display Chart At That Location.
       Point myPieLocation = new Point(10, 400);
       //Set Size Of The Chart
       Size myPieSize = new Size(500, 500);
       //Call Function Which Will Draw Pie of Values.
       DrawPieChart(myPiePercent, myPieColors, e.Graphics, myPieLocation, myPieSize);
    }
