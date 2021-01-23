    private static int FindStudentPosition(string name, string[] array)
    {
        int intLocation = -1;
        //loops through all array elements
        for (int i = 0; i < array.Length; i++; )
        {
            //checks if array element matches name
            if (array[i] == name)
            {
                //displays message and stores position in intLocation
                Console.WriteLine("Matches Name " + i);
                intLocation = i;
            }    
            break;
        }
        return intLocation;
    }
