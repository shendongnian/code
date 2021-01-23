    public IEnumerable<SelectListItem> GetTrainingSubjectsList(int selectedValue)
            {
                List<SelectListItem> TrainingSubjectsList = new List<SelectListItem>();
    
                TrainingSubjectsList.Add(new SelectListItem() { Selected = true, Text = "Select Subject", Value = "" });
                var TrainingSubjects = (from subjects in _context.TrainingDetails.Where(c => c.IsDeleted == false)
                                        select subjects).ToList();
    
                foreach (TrainingDetail TrainingDetail in TrainingSubjects)
                {
                    SelectListItem Item = new SelectListItem();
    
                    Item.Text = TrainingDetail.Title;
                    Item.Value = TrainingDetail.TrainingDetailId.ToString();
    
                    if (selectedValue == TrainingDetail.TrainingDetailId)
                    {
                        Item.Selected = true;
                    }
    
                    TrainingSubjectsList.Add(Item);
                }
    
                return TrainingSubjectsList;
            }
