    model.GroupedTypeOptions = this.UnitOfWork.CategoryRepository.Get()
         .Where(t => t.ParentCategory != null)
         .OrderBy(t => t.ParentCategory.Name).ThenBy(t => t.Name)
         .Select(t => new GroupedSelectListItem
         {
             GroupKey = t.ParentId.ToString(),
             GroupName = t.ParentCategory.Name,
             Text = t.Name,
             Value = t.Id.ToString()
         }
     );
