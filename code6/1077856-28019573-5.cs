    public static void getMethod(int x, Form1 form)
    {
        if (x > 4)
        {
            form.AppendFieldText("Text");
        }
        else
        {
            form.AppendFieldText("Other text");
            otherVariable = x;
        }
    }
