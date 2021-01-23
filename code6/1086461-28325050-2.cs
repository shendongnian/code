    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Packaging;
    using System.Xml.Linq;
    using System.Linq;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using DocumentFormat.OpenXml.Drawing;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            public const string documentRelationshipType = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument";
            static void Main(string[] args)
            {
                IDictionary<string, string> toReplace = new Dictionary<string, string>();
                toReplace.Add("Sample2", "Sample - Text!");
                toReplace.Add("Sample3", "Sample 3 - Text!");
    
                using (PresentationDocument presentationDocument = PresentationDocument.Open("C:\\Users\\beggers\\Desktop\\ppt.pptx", true))
                {
                    // Get the presentation part of the presentation document.
                    PresentationPart presentationPart = presentationDocument.PresentationPart;
    
                    // Verify that the presentation part and presentation exist.
                    if (presentationPart != null && presentationPart.Presentation != null)
                    {
                        // Get the Presentation object from the presentation part.
                        Presentation presentation = presentationPart.Presentation;
    
                        // Verify that the slide ID list exists.
                        if (presentation.SlideIdList != null)
                        {
                            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())
                            {
                                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;
    
                                ShapeTree tree = slidePart.Slide.CommonSlideData.ShapeTree;
                                foreach (DocumentFormat.OpenXml.Presentation.Shape shape in tree.Elements<DocumentFormat.OpenXml.Presentation.Shape>())
                                {
                                    // Run through all the paragraphs in the document
                                    foreach (Paragraph paragraph in shape.Descendants().OfType<Paragraph>())
                                    {
                                        foreach (DocumentFormat.OpenXml.Drawing.Run run in paragraph.Elements<Run>())
                                        {
                                            foreach (var kvp in toReplace)
                                            {
                                                if (run.Text.InnerText.Contains(kvp.Key))
                                                {
                                                    run.Text = new DocumentFormat.OpenXml.Drawing.Text(kvp.Value);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
