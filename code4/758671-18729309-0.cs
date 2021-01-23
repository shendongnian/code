    var context = new ParserContext();
    context.XamlTypeMapper = new XamlTypeMapper(
      new[] {
        Assembly.GetExecutingAssembly().GetName().Name,
        "Assembly1",
        "Assembly2",
        "Assembly3",
        "Assembly4",
      }
    );
    var element = (FrameworkElement) XamlReader.Parse(xaml, context);
