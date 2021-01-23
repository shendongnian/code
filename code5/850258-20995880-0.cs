    var appliedTaxes = new List<TaxApplied>();
    appliedTaxes.Add(new TaxApplied { ID = 1, ProductID = 1 });
    var model = new Product { AppliedTaxes = appliedTaxes };
    var items = appliedTaxes.Select(t => new SelectListItem { Text = t.ID.ToString(), Value = t.ProductID.ToString() }).ToList();
    ViewBag.AppliedTaxes = new MultiSelectList(items);
