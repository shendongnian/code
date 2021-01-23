    UserFile item = new UserFile();
    unitOfWork.UserFileRepository.Add(item);
    unitOfWork.SaveChanges();//Database generates key 
                             //and EF fixes its in-memory version
    Document entity = new Document();
    entity.Name = model.Name;
    entity.Description = model.Description;
    entity.UserFileID = item.ID; //use the foreign key to avoid duplicate
    unitOfWork.DocumentRepository.Add(entity);
    unitOfWork.SaveChanges();
