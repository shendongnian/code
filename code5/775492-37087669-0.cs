    var tempFileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".xlsx");
    using (var file = new FileStream(tempFileName, FileMode.CreateNew))
    {
        OpenXmlBuilder.Write(
            file, 
            new[] {
                new Worksheet(
                    "Parameters",
                    null,
                    new Row(new InlineString("Name"), new InlineString("Value")),
                    new Row(new InlineString("Height"), new DecimalCell(123m))
                )
            }
        );
    }
    Process.Start(tempFileName);
