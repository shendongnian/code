    foreach (string line in faceLines)
    {
        IFace face; 
        if (FaceParser.TryParse(line, out face))
        {
            faces.Add(face);
        }
    }
