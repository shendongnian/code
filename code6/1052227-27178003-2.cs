    public void score(Label n, ref int m)
    {
        switch (n.Text)
        {
            case "J": 
            case "Q":
            case "K": m += 10; break;
            case "A": m += 11; break;
            default: m += Convert.ToInt32(n.Text); break;
        }
    }
---
    score(label7, ref playerTotal);
