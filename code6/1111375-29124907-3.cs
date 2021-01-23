    static void SwapNums(string[,] theBoard, string number)
    {
        var numberPosition = GetPosition(theBoard, number);
        var minusPosition = GetPosition(theBoard, "-");
        if (numberPosition.Item1 == -1 || minusPosition.Item1 == -1)
            throw new Exception("Element " + number + " or - was not found in theBoard!");
        if (numberPosition.Item1 == minusPosition.Item1) //they are in the same row
        {
            if (numberPosition.Item2 + 1 == minusPosition.Item2 ||
                numberPosition.Item2 - 1 == minusPosition.Item2) // if they are next to eachother
            {
                theBoard[numberPosition.Item1, numberPosition.Item2] = "-";
                theBoard[minusPosition.Item1, minusPosition.Item2] = number;
            }
        }
        else if (numberPosition.Item2 == minusPosition.Item2) // same column
        {
            if (numberPosition.Item1 + 1 == minusPosition.Item1 ||
                numberPosition.Item1 - 1 == minusPosition.Item1) //if they are above or below
            {
                theBoard[numberPosition.Item1, numberPosition.Item2] = "-";
                theBoard[minusPosition.Item1, minusPosition.Item2] = number;
            }
        }
    }
