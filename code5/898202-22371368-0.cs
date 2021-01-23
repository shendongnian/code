    public void AddBoxToSpaces(List<Space> ListofSpaces)
    {
        Boolean Boxfits, Boxplaced;
        foreach (Space space in ListofSpaces)
        {
            foreach (Box box in ListofBoxes)
            {
                Boxfits = checkboxfits.Checkboxfits(box, space);
                if (Boxfits == true)
                {
                    Boxplaced = placethebox.Placethebox(box, space);
                    if (Boxplaced == true)
                    {
                        //ListofSpaces = dividespace.Dividespace(box, space);
                        AddBoxToSpaces(dividespace.Dividespace(box, space));
                    }
                }
            }
        }
    }
