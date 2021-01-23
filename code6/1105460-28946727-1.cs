    while (i < count) {
        if (broken[i] != null) {
            var tmp = broken[i].ToLower();
               items = items.Where(x => x.Title.ToLower().Contains(tmp));
            }
            i++;
        }
    }
