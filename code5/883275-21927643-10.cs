    ....
    ClassifiedsViewModel viewModel = new ClassifiedsViewModel();
    viewModel.Classifieds = db.Classifieds.Find(id);
    viewModel.Comments = db.LoadCommentsByClassifiedsId(id); //create db method
    // or instead of this line use:
    viewModel.Comments = db.ClassifiedsComments.Where(e => e.C_Unique_Id == id).ToList();
    
    return(viewModel);
