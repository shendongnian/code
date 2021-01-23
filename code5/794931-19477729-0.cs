    var result = myList.Select(qData => new QData()
        {
            Items = qData.Items,
            Dates = qData.Dates.OrderBy(qDay => DateTime.Parse(qDay.Date)).ToList();
        }).ToList();
