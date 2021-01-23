    XElement sectionOne = doc.Descendants(namespace + "AssessmentSection").First(x => x.Attribute("sectionNameID").Value.Equals("SECTION_ONE"));
            IEnumerable<XElement> elements = sectionOne.Elements(namespace + "SectionItem");
            foreach (XElement element in elements) 
            {
                //Do something
            }
