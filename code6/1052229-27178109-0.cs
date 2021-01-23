    public int getScore(Label n)
    {
        switch (n.Text)
        {
            case "J":
            case "Q":
            case "K":
                return 10;
            case "A":
                return 11;
            default:
                return Convert.ToInt32(n.Text);
        }
    }
...
    playerTotal += getScore(label7);
