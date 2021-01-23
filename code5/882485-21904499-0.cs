    // saving data in file
    if (currentStep == MaxSteps)
    {
        using (FileStream fs1 = new FileStream("data.txt", FileMode.OpenOrCreate,
            FileAccess.Write))
        using (StreamWriter writer = new StreamWriter(fs1))
        {
            foreach (double x in theSpace.TheCells[a, b, 0].PointDataOutput)
            {
                writer.WriteLine(x);
            }
            writer.WriteLine(theSpace.TheCells[a, b, 0].PointDataOutput.ToString);
        }
    }
