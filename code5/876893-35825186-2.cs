    var contentItemRepository = _workContext.Resolve<IRepository<ContentItemRecord>>();
    var contentItemRecord = contentItemRepository.Get(Model.ContentItem.Id);
    if (contentItemRecord == null) {
        isNew = true;
    }
