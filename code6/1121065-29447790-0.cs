    bool itemExists = true;
    foreach (int[] ints in finalList)
    {
        if (ints.Length != tmpArray.Length)
        {
            itemExists = false;
            break;
        }
        else
        {
            // Compare each element
            for (int i = 0; i < tmpArray.Length; i++)
            {
                if (ints[i] != tmpArray[i])
                {
                    itemExists = false;
                    break;
                }
            }
            
            // Have to check to break from the foreach loop
            if (itemExists == false)
            {
                break;
            }
        }
    }
    
    if (itemExists == false)
    {
        finalList.add(tmpArray);
    }
