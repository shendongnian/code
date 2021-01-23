    // read the file into an array of strings - consider File.ReadAllLines() - perhaps name the array it produces "fileLines"
    // iterate over the fileLines array processing one array element at a time - a good method would be to use a foreach loop
    foreach(string fileLine in fileLines)
    {
        // TODO: isolate the part of the string between the parenthesis
        // split the string on commas to create a string array
        var coordinates = fileLine.Split(new char[',']);
        // if there the number of string array elements is correct, allocate a Point3D element
        if (coordinates.length != 3)
        {
            throw new ApplicationException(string.Format("Invalid number of coordinates. Expected 3, got {0}.", coordinates.Length));
        }
        // use float.TryParse() to load each element of the string array into the proper member of its struct or class
        float xCoordinate;
        float yCoordinate;
        float zCoordinate;
        if (! float.TryParse(coordinates[0], out xCoordinate)
        {
            throw new ApplicationException(string.Format("Unable to parse X-coordinate {0}.", coordinates[0]));
        }
        if (! float.TryParse(coordinates[1], out yCoordinate)
        {
            throw new ApplicationException(string.Format("Unable to parse Y-coordinate {0}.", coordinates[1]));
        }
        if (! float.TryParse(coordinates[2], out zCoordinate)
        {
            throw new ApplicationException(string.Format("Unable to parse Z-coordinate {0}.", coordinates[2]));
        }
        Point3D point3D = new Point3D(xCoordinate, yCoordinate, zCoordinate);
        // TODO: stuff this point3D into an array or collection to save it
        // process the next line of the file...
    }
