    public decimal GetTestScore(int score, out string status)
    {
        status = string.Empty;
        if (score < 10)
        {
            status = "FAILED";
            return 0m;
        }
        return Math.Ceiling(score / 10m);
    }
