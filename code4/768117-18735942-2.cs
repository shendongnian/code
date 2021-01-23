    // selector is a function that compares two projects and returns true if we should keep the new one
    static void GetIndexes(List<Employee> emplist, out int index, out int subindex, Func<project, project, bool> selector) {
        index = -1;
        subindex = -1;
        project selected = null;
        for (int i = 0; i < emplist.Count; i++) {
            var emp = emplist[i];
            for (int j = 0; j < emp.Projects.Count; j++) {
                var prj = emp.Projects[j];
                if (selected == null || selector(selected, prj)) {
                    selected = prj;
                    index = i;
                    subindex = j;
                }
            }
        }
    }
