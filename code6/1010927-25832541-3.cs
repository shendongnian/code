    for(int i = 0; i < allSets.Count; ++i) {
        for(int j = i + 1; j < allSets.Count; ++j) {
            count = 0;
            if(allSets[i].Count < allSets[j].Count) {
                loopingSet = allSets[i];
                containsSet = allSets[j];
            } else {
                loopingSet = allSets[j];
                containsSet = allSets[i];
            }
            foreach(int k in loopingSet) {
                if(containsSet.Contains(k)) {
                    ++count;
                }
            }
        }
    }
