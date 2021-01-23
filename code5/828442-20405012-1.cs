    int maxLength = 3;
    double number = 1.96;
    string output = null;
    int decimalPlaces = maxLength - 2; //because every decimal contains at least "0."
    bool isError = true;
    
    while (isError && decimalPlaces >= 0)
    {
        output = Math.Round(number, decimalPlaces).ToString();
        isError = output.Length > maxLength;
        decimalPlaces--;
    }
    
    if (isError)
    {
        //handle error
    }
    else
    {
        //we got result
        Debug.Write(output);
    }
