    StringBuilder binaryBuilder = new StringBuilder();
    for (int ii = 0; ii < arrBoolean.Length; ii++)
    {
        if (arrBoolean[ii])
            binaryBuilder.Append("1");
        else
            binaryBuilder.Append("0");
    }
    string decimalString = Convert.ToInt32(binaryBuilder.ToString(), 2).ToString();
