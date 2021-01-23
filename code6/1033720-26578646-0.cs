    var proviences = lookupRepository.GetProviences();
    IEnumerable<SelectListItem> selectListProvience = (from p in proviences).AsEnumerable()
      .Select(p => new SelectListItem
      {
         Text = p.ProvinceName,
        ....
