     protected override void Execute(CodeActivityContext context)
     {
        var summaryReport = new CustomSummaryInformation()
        {
        Message = "Your message",
        SectionPriority = 0,
        SectionHeader = "Header name",
        SectionName = "SectionName",
        };
        context.Track(summaryReport);
    }
