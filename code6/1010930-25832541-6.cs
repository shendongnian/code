    HashSet<int> intersect;
    HashSet<int> intersectWith;
            if(allSets[i].Count < allSets[j].Count) {
                intersect = new HashSet<int>(allSets[i]);
                intersectWith = allSets[j];
            } else {
                intersect = new HashSet<int>(allSets[j]);
                intersectWith = allSets[i];
            }
            intersect.IntersectWith(intersectWith);
            count = intersect.Count;
        }
    }
