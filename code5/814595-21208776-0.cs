    private Dictionary<string, string> GetShapeMasters(Powerpoint.Slide s)
    {
        Dictionary<string, string> shapeMasters = new Dictionary<string, string>();
        List<ShapeLocation> shapeLocations = new List<ShapeLocation>();
        //store locations
        foreach (Powerpoint.Shape sh in s.Shapes)
        {
            shapeLocations.Add(new ShapeLocation()
            {
                Name = sh.Name,
                Location = new System.Drawing.RectangleF(sh.Left, sh.Top, sh.Width, sh.Height)
            });
        }
        //have powerpoint reset the slide
        //ISSUE: this changes the names of placeholders without content.
        s.CustomLayout = s.CustomLayout;
        //compare slide and master
        foreach (Powerpoint.Shape sh in s.Shapes)
        {
            foreach (Powerpoint.Shape msh in s.CustomLayout.Shapes)
            {
                if (IsShapeMaster(sh, msh))
                {
                    shapeMasters[msh.Name] = sh.Name;
                }
            }
        }
        //restore locations
        //TODO: might be replaced by undo
        foreach (var shm in shapeLocations)
        {
            Powerpoint.Shape sh = null;
            try
            {
                sh = s.Shapes[shm.Name];
            }
            catch 
            {
                //Fails for renamed placeholder shapes.
                //Have yet to find a decent way to check if a shape name exists.
            }
            //placeholders do not need to be restored anyway.
            if (sh != null)
            {
                sh.Left = shm.Location.Left;
                sh.Top = shm.Location.Top;
                sh.Width = shm.Location.Width;
                sh.Height = shm.Location.Height;
            }
        }
        return shapeMasters;
    }
