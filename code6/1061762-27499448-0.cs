    @Html.DropDownListFor(model => model.BuyMoreList[i].FolioNo,
    new SelectList(Model.BuyMoreList[i].FolioDividendList.GroupBy(x => x.FolioNo)
                        .Select(x =>
                           {
                               var firstSet = x.First();
                               return new SelectListItem
                               {
                                   Value = firstSet.FolioNo.ToString(),
                                   Text = firstSet.FolioNo
                               };
                            }
                   ),"Value", "Text")
