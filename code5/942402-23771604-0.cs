    public async Task<IEnumerable<NewsCategoryDto>> GetNewsCategoriesWithRecentNews(int count)
    {
      using (var UoW = new UnitOfWork())
      {
        List<NewsCategoryDto> returnList = new List<NewsCategoryDto>();
        var activeAndVisibleCategories = UoW.CategoryRepository.GetActiveCategories().Where(f => f.IsVisible == true);
        foreach (var category in activeAndVisibleCategories)
        {
          var dto = category.MapToDto();
          dto.RecentNews = await (from n in UoW.NewsRepository.GetByCategoryId(dto.Id).Where(f => f.IsVisible == true).Take(count)
              select n.MapToDto(true)).ToListAsync();
          returnList.Add(dto);
        }
        return returnList;
      }
    }
