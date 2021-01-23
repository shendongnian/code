    [HttpGet]
    public ActionResult GetPeopleByName(String term, PageInfo pageinfo) {
        var matches = this.people.Where(i => i.Name.Contains(term));
        var pagedResult =  new PagedResult<AnySearchType>{
                data = matches.Skip(pageinfo.skip).Take(pageinfo.size).OrderBy(i => i.Name),
                total = matches.Count()
            };
        return Json(
            data: pagedResult,
            behavior: JsonRequestBehavior.AllowGet
        );
    }
