    IEnumerable<KeyValuePair<string, int>> GetSelectedCategories(
            IEnumerable<string> selected)
    {
        foreach (var item in selected)
        {
            foreach (var category in _repo.GetAllDCategories(item))
            {
                yield return new KeyValuePair<string, int>(
                    category.Name,
                    category.Id);
            }
        }
    }
