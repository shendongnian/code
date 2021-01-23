    var numberOfPupils = pupils.Count();
    for (int i = 0; i < numberOfPupils; i++)
    {
        if (pupils[i].groupid == "00")
        {
            pupils[i].groupid = "yourCustomAssignedId";
        }
    }
