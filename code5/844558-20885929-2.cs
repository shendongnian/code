    var withParents = this.UnitOfWork.CategoryRepository.Get()
        .Where(t => t.ParentCategory != null);
    var withoutParents = this.UnitOfWork.CategoryRepository.Get()
        .Where(t => t.ParentCategory == null);
    model.GroupedTypeOptions = withParents.Concat(withoutParents)
        .OrderBy(t => t.Name)
        .Select(t => new GroupedSelectListItem
        {
            GroupKey = (t.ParentId != null) ? t.ParentId.ToString() : "",
            GroupName = (t.ParentCategory != null) ? t.ParentCategory.Name : "",
            Text = t.Name,
            Value = t.Id.ToString() // I assume Id can never be null
        });
