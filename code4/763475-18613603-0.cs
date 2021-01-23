    string[] array = value.Split(Enum.enumSeperatorCharArray);
    ulong[] array2;
    string[] array3;
    Enum.GetCachedValuesAndNames(runtimeType, out array2, out array3, true, true);
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = array[i].Trim();
        bool flag = false;
        int j = 0;
        while (j < array3.Length)
        {
            if (ignoreCase)
            {
                if (string.Compare(array3[j], array[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    goto IL_152;
                }
            }
            else
            {
                if (array3[j].Equals(array[i]))
                {
                    goto IL_152;
                }
            }
            j++;
            continue;
            IL_152:
            ulong num2 = array2[j];
            num |= num2;
            flag = true;
            break;
        }
        if (!flag)
        {
            parseResult.SetFailure(Enum.ParseFailureKind.ArgumentWithParameter, "Arg_EnumValueNotFound", value);
            return false;
        }
    }
