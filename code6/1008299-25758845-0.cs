    IEnumerable<string> Proposed_By = 
            from project in xmldoc.Descendants("Projects").Elements("Project")
            where project.Attribute("Country") != null 
                  and project.Attribute("Country").Value == "Canada"
                  and project.Attribute("ProposedBy") != null
            select project.Attribute("ProposedBy").Value;
