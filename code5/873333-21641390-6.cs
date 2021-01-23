    Car Car1 = new Car();
    //code to get car object
    IList<Part> AllParts = new List<Part>();
    GetSubParts(Car.AllParts, ref AllParts); //call a recursive method to add all the parts and subparts to the list
    //do something with the list
    public void GetSubParts(IList<Part> parentList, ref IList<Part> partsList)
    {
        foreach (Part part in parentList)
        {
            partsList.Add(part); //add this part to the list
            if (part.SubParts.Count > 0) //if this part has subparts
                GetSubParts(part.SubParts, ref partsList); //add all the subparts of this part to the list too
        }
    }
