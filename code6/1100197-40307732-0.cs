    public static int ThaiLength(string text)
    {
        string thai3level = "อิอีอึอือุอูอ์อ่อ้อ๊อ๋อัอํอฺ";
        int c = 0;
        for (int i = 0; i < text.Length; ++i) {
            if (text.ToCharArray()[i]=='อ' || thai3level.IndexOf(text.ToCharArray()[i]) < 0) {
                ++c;
            }
        }
        return c;
    }
