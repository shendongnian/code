    new SvgDocument
    {
        Width = 100,
        Height = 100,
        FontSize = 10,
        Nodes =
        {
            new SvgText
            {
                Nodes = {new SvgContentNode {Content = "my text"}},
                X = {10},
                Y = {10}
            }
        }
    }
