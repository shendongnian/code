        public static List<Panel> GetPanelsWithSameTestedDrugs(List<Panel> panelList, Panel selectedPanel)
        {
            var testedDrugs = panelList
                .Where(panel => panel == selectedPanel)
                .SelectMany(panel => panel.Drugs)
                .SelectMany(drugClass => drugClass.TestedDrugs)
                .Distinct()
                .OrderBy(testedDrug => testedDrug.ID);
            var panels = panelList.Where(panel => panel.DrugClasses
                                        .SelectMany(drugClass => drugClass.TestedDrugs)
                                        .Distinct()
                                        .OrderBy(testedDrug => testedDrug.ID)
                                        .SequenceEqual(testedDrugs));
            return panels.ToList();
        }
