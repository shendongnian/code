    // Returns if v1 has won, tied or lost from v2. (Left to right)
    private WinResult CompareForWinner(Choice v1, Choice v2)
    {
        if (v1 == Choice.Paper)
        {
            if (v2 == Choice.Paper)
                return WinResult.Tie;
            if (v2 == Choice.Rock)
                return WinResult.Lost;
            return WinResult.Won;
        }
        if (v1 == Choice.Rock)
        {
            if (v2 == Choice.Paper)
                return WinResult.Lost;
            if (v2 == Choice.Rock)
                return WinResult.Tie;
            return WinResult.Won;
        }
        // v1 = Scissor.
        if (v2 == Choice.Paper)
            return WinResult.Won;
        if (v2 == Choice.Rock)
            return WinResult.Lost;
        return WinResult.Tie;
    }
