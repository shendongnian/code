    var panel = // take from db
    var allTestedDrugs = panel.DrugClasses.SelectMany(dg => dg.TestedDrugs).ToList();
    var samePanels = panel.DrugClasses.SelectMany(dg => dg.Panels).Distinct();
                    .Where(p => allTestedDrugs.All(
                        testedDrug => p.DrugClasses.SelectMany(dg => dg.TestedDrugs)
                                                .Any(td => testedDrug.Id == td.Id))
                    );
