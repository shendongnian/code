        var results = new List < Product > ();
        if (strStatus == "ALL" || txtProd == "" || txtTitle == "")
            results = p;
        else
            foreach(var prod in p) {
                if (prod.ID == Int32.Parse(txtProd)) {
                    results.Add(prod);
                }
                if (prod.Title.ToUpper() == txtTitle) {
                    results.Add(prod);
                }
                if (prod.Status.ToUpper() == strStatus) {
                    results.Add(prod);
                }
            }
        results = results.Distinct()
            .ToList();
