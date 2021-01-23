    static void Main(string[] args)
    {
        var file = @"C:\Users\kjennings\Desktop\Test PPTs\This is the Title - Copy.pptx";
        var index = 0;
        //open the document here for use throughout the application
        using (var ppt = PresentationDocument.Open(file, false))
        {
            var slidePart = GetSlidePart(ppt, index);
            var images = slidePart.Slide.Descendants<Picture>().Select(p => p);
            foreach (var image in images)
            {
                // Just placeholder code below.  It now gets here...
                var pic = image;
            }
        }
    }
    //pass the open document in here...
    public static SlidePart GetSlidePart(PresentationDocument ppt, int slideIndex)
    {
        // Get the relationship ID of the first slide.
        var presentationPart = ppt.PresentationPart;
        // Verify that the presenation part and the presenation exist,
        if (presentationPart != null && presentationPart.Presentation != null)
        {
            var presentation = presentationPart.Presentation;
            if (presentation.SlideIdList != null)
            {
                var slideIds = presentation.SlideIdList.ChildElements;
                if (slideIndex < slideIds.Count)
                {
                    // Get the relationship ID of the slide.
                    var slidePartRelationship = (slideIds[slideIndex] as SlideId).RelationshipId;
                    // Get the specified slide part from the relationship ID.
                    var slidePart = (SlidePart)presentationPart.GetPartById(slidePartRelationship);
                    return slidePart;
                }
            }
        }
        // No slide found.
        return null;
    }
