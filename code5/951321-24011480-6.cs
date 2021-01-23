    RenderedOutput = HtmlHelper.GridFor(Model)
    .WithColumns(columnFactory =>
    {
        columnFactory.New().Bind(x => x.Name)
            .WithCss("inline");
        columnFactory.New().Bind(x => x.Age)
            .WithCss("inline fixed right");
    })
    .Render();
