    var allCategories = categoryRepository.AllIncluding(category => category.Plans);
            Dictionary<Category, Dictionary<Category, List<Category>>> list = new Dictionary<Category, Dictionary<Category, List<Category>>>();
            foreach (var l1 in allCategories.Where(e => e.CategoryUID == null)) {
                Dictionary<Category, List<Category>> l1List = new Dictionary<Category, List<Category>>();
                foreach (var l2 in allCategories.Where(e => e.CategoryUID == l1.UID)) {
                    List<Category> l2List = new List<Category>();
                    foreach (var l3 in allCategories.Where(e => e.CategoryUID == l2.UID)) {
                        l2List.Add(l3);
                    }
                    l1List.Add(l2, l2List);
                }
                list.Add(l1, l1List);
            }
            var finalList = list;
