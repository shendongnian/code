    public Boolean IsAllLetters(String name)
    {
        for (Int32 i = 0; i < name.Length; i++)
        {
            if ((Int32)name[i] < 65 || ((Int32)name[i] > 90 && (Int32)name[i] < 97) || (Int32)name[i] > 122)
                return false;
        }
        return true;
    }
