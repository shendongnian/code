    public void OnEditDesignerSection(Guid sectionId, string sectionName)
        {
            DesignerAssitModel viewModel = GetModelIntance();
            string name = viewModel.EditSectionItem(sectionId, sectionName);
            HttpContext.Application["DesignerAssit"] = name; // Sets HttpContext.Application["DesignerAssit"] to 'Bob'
        }
