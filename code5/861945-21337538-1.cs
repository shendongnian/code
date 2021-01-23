    var r = req.OrderByDescending(x => new[]
    {
        x.CreatedOn,
        (x.Responses ?? new List<Response>()).Select(y => y.CreatedOn).Max(),
        (x.Responses ?? new List<Response>()).Select(y => (y.Dialogs ?? new List<Dialog>())
                                    .Select(z => z.CreatedOn).Max()).Max()
    }.Max()).Select(x => x).ToList();
