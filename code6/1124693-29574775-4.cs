    var panel = // take from db
    var panels = // get all from db
    var allTestedDrugs = panel.DrugClasses.SelectMany(dg => dg.TestedDrugs).ToList();
    var samePanels = panels.Where(p => allTestedDrugs.All(
                        testedDrug => p.DrugClasses.SelectMany(dg => dg.TestedDrugs)
                                                .Any(td => testedDrug.Id == td.Id))
                    );
