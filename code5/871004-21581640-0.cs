    public static void GetSomething(this HtmlHelper helper, List<int> items)
    {
        foreach (var num  in items)
        {
            helper.RenderPartial("Test", num);
        }
    }
