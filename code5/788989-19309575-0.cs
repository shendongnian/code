    public void count(int inVal)
    {
        if (inVal == 0)
            return;
        count(inVal - 1);
        // arrays are 0-based, so the person in chair 1 is at array element 0
        Console.WriteLine("{0} is sitting in chair {1}", myStudents[inVal-1], inVal);
    }
