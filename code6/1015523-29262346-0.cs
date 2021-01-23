    static void Main(string[] args)
    {
        using (var p = PresentationDocument.Open(@"SmartArt.pptx", true))
        {
            foreach (var slide in p.PresentationPart.GetPartsOfType<SlidePart>().Where(sp => IsVisible(sp)))
            {
	            foreach(var diagramPart in slide.DiagramDataParts)
	            {
                    foreach(var text in diagramPart.RootElement.Descendants<Run>().Select(d => d.Text.Text))
                    {
                        Console.WriteLine(text);
                    }
	            }
            }
        }
        Console.ReadLine();
    }
    private static bool IsVisible(SlidePart s)
    {
        return (s.Slide != null) &&
          ((s.Slide.Show == null) || (s.Slide.Show.HasValue &&
          s.Slide.Show.Value));
    }
