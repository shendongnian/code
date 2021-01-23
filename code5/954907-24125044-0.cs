    public string EditSectionItem(Guid sectionId, string sectionName)
        {
            string name = "Bob";
            DesignerSection section = Sections.Where(s => s.Id == sectionId).FirstOrDefault<DesignerSection>();
            DesignerSection itemToEdit = Sections.Where(n => n.Name == sectionName).FirstOrDefault<DesignerSection>();
            section.Name.Equals(section.Name);
            return name;
        }
