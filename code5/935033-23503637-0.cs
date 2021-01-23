    while (myReader.Read())
    {
        if ((myReader.Name == "CONTAINER"))
        {
            ProcessContainerElement(myReader);
        }
    }
