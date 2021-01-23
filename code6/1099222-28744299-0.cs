    List<string> originalList = new List<string> {"A", "T", "G", "F", "V", "E", "W", "Q"};
    List<string> compareList = new List<string> {"T", "F", "V", "A"};
    var intersectedItems = compareList.Intersect(originalList);
    var notIntersectedItems = originalList.Except(compareList);
    var resultList = intersectedItems.Concat(notIntersectedItems).ToList();
