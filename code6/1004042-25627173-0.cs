    List<Int32> indexes = new List<Int32>();
    bool wasValid = false;  // flag if previous item was valid
    for (int i = 0; i < myArray.Count; i++)
        {
            if (IsValidText(myArray[i]))
            {
                if (!wasValid) // previous item was not valid
                    indexes.Add(i);  // note fix to keep as 0-based index 
                wasValid = true;
            }   
            else
            {
                wasValid = false;  // for next loop
            }
        }
