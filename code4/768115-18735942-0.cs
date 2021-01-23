    int index = -1;
    int subindex = -1;
    int maxID = -1;
    for (int i = 0; i < emplist.Count; i++) {
        var emp = emplist[i];
        for (int j = 0; j < emp.Projects.Count; j++) {
            if (emp.Projects[j].ID > maxID) {
                maxID = emp.Projects[j].ID;
                index = i;
                subindex = j;
            }
        }
    }
