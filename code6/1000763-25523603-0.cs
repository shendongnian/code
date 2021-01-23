    for(int i = 0; i < userfield.GetLength(0); i++)
    {
        for(int j = 0; j < userfield.GetLength(1); j++)
        {
           //TODO: validate the user input before parsing the integer
           userfields[i,j] = Convert.ToInt32(Console.ReadLine());
        }
    }
