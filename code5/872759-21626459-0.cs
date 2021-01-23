    ViewBag.SortBedragParameter = string.IsNullOrEmpty(sortBy) ? "Bedrag_desc" : "";
        ViewBag.SortDatumParameter = sortBy == "DatumBetaling" ? "DatumBetaling_desc" : "DatumBetaling";
        ViewBag.SortStatusParameter = sortBy == "StatusBetaling" ? "Status_desc" : "StatusBetaling";
        var betalingen = betalingBLL.GetAll();
        switch (sortBy)
        {
           case "Bedrag_desc":
                    betalingen = betalingen.OrderByDescending(x => x.Bedrag);
                    break;
           case "DatumBetaling_desc":
                    betalingen = betalingen.OrderByDescending(x => x.DatumBetaling);
                    break;
           case "DatumBetaling":
                    betalingen = betalingen.OrderBy(x => x.DatumBetaling);
                    break;
            case "Status_desc":
                    betalingen = betalingen.OrderByDescending(x => x.StatusBetalingID);
                    break;
            case "StatusBetaling":
                    betalingen = betalingen.OrderBy(x => x.StatusBetalingID);
                    break;
            default:
                    betalingen = betalingen.OrderBy(x => x.Bedrag);
                    break;
         }
         return View(betalingen.ToList());
