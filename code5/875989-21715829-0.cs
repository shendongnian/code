    private void SaveImage(SmllcImage image, List<string> theList)
    {
        for (int i = 0; i < image.SourceImages.Count; i++)
        {
            string newfilepath = "some file path";
            image.SourceImages[i].Save(newfilepath);
            theList.Add(newfilepath);
        }
    }
