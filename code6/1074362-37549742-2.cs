     public PartialViewResult InhoudByIdPartial(int id)
            {
                return PartialView(
                    db.EventBericht.Where(r => r.EventID == id).ToList());
    
            }
    
