    using (isolatedFileStream = dataFile.OpenFile(filename, FileMode.Open, FileAccess.ReadWrite))
    {
        // Read the data from the file.
        XmlSerializer serializer = new XmlSerializer(typeof(Data));
        // Store each of the deserialized data objects in the list.
        Data savedData = (Data)serializer.Deserialize(isolatedFileStream);
        // Loop through the saved data objects.
        for(int i = 0; i < savedData.Levels.Count; i++)
        {
            System.Diagnostics.Debug.WriteLine("I am inside the loop and my index is" + i);
            // Get the data object in question.
            LevelData levelData = savedData.Levels[i];
            // Check to see if the index of the data object corresponds to the active level index.
            if (levelData.Index == mLevelIndex)
            {
                // Check that the attempts already saved is less.
                if (levelData.Attempts < mLevel.AttemptCounter)
                    levelData.Attempts = mLevel.AttemptCounter;
                // Check that the 
                if (levelData.PercentComplete < 50)
                    levelData.PercentComplete = 50;
            }
        }
        isolatedFileStream.Seek(0, SeekOrigin.Begin);
        serializer.Serialize(isolatedFileStream, savedData);
        isolatedFileStream.SetLength(isolatedFileStream.Position);
    } 
