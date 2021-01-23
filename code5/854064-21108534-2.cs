     protected override void Execute(CodeActivityContext context)
     {
        var summaryReport = new CustomSummaryInformation()
        {
        Message = "Your message",
        SectionPriority = 0,
        SectionHeader = "Header Name",
        SectionName = "Section Name",
        };
        context.Track(summaryReport);
    }
