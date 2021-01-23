    readonly Dictionary<Point,PictureBox> _dynamicMappedBoxes = 
             new Dictionary<Point,PictureBox>();
    // Call this once in the beginning ofr your program
    void createDynamicMapping()
    {
        foreach(PictureBox box in Controls.OfType<PictureBox>())
        {
            Point coords = getCoordinatesFromName(box);
            _dynamicMappedBoxes.Add(coords, box);
        }
    }
    
    Point getCoordinatesFromName(PictrueBox box)
    {
        int x = int.Parse(box.Name.SubString(IdontKnow);
        int y = int.Parse(box.Name.SubString(IdontKnow);
        retrun new Point(x,y);
    }
    //usage
    string colorName = dynamicMappedBoxes[new Point(x,y)].BackColor.ToString();
