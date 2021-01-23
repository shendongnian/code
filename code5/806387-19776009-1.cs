    string input = "this is a a1234 b5678 test string";
    string output = "";
    string[] temp = input.Trim().Split(' ');
    bool previousNum = false;
    string tempOutput = "";
    foreach (string word in temp)
    {
        if (word.ToCharArray().Where(x => char.IsDigit(x)).Count() > 0)
        {
            previousNum = true;
            tempOutput = tempOutput + word;
        }
        else
        {
            if (previousNum)
            {
                if (tempOutput.Length >= 4) tempOutput = "xxxx" + tempOutput.Substring(tempOutput.Length - 4, 4);
                output = output + " " + tempOutput;
                previousNum = false;
            }
            output = output + " " + word;
        }
    }
    if (previousNum)
    {
        if (tempOutput.Length >= 4) tempOutput = "xxxx" + tempOutput.Substring(tempOutput.Length - 4, 4);
        output = output + " " + tempOutput;
        previousNum = false;
    }
