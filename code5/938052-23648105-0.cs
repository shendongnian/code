      public static void SaveProduct(ProductEntity product) {
            using (var db = ProductEntities()) {
                //stored references to duplicate entities added to the objectContext
                var duplicateGroupsAdded = new List<Tuple<CategoryEntity, GroupEntity>>();
                var duplicateCategoriesAdded = new List<Tuple<ProductEntity, CategoryEntity>>();
                //using existing instace of entities includes associated parent into db update causing duplicate product insert attempt.
                //entities saved must be newly instantiated with no existing relationships.
                var categories = product.Categories.ToList();
                var type = new TypeEntity() {
                    Id = product.Type.Id,
                    Name = product.Type.Name
                };
                //empty the  collection 
                product.Categories.ToList().ForEach(category => {
                    product.Categories.Remove(category);
                });
                //start off with clean product that we can populate with related entities
                product.Type = null;
                product.Group = null;
                //add to db
                db.Products.AddObject(product);
                categories.ForEach(oldCategory => {
                    //new cloned category free of relationships
                    var category = new CategoryEntity() {
                        Id = oldCategory.Id,
                        Name = oldCategory.Name
                    };
                    //copy accross Groups as clean entities free of relationships
                    foreach (var group in oldCategory.Groups) {
                        category.Groups.Add(new GroupEntity() {
                            Id = group.Id,
                            Name = group.Name
                        });
                    }
                    //if the cat is alreay in the db use reference to tracked entity pulled from db
                    var preexistingCategory = db.Categories.SingleOrDefault(e => e.Id == category.Id);
                    if (preexistingCategory != null)
                        product.Categories.Add(preexistingCategory);
                    else {
                        //category not in database, create new
                        var Groups = category.Groups.ToList();
                        category.Groups.ToList().ForEach(group => category.Groups.Remove(group));
                        Groups.ForEach(Group => {
                            //if the group is alreay in the db use reference to tracked entity pulled from db
                            var preexistingGroup = db.Groups.SingleOrDefault(e => e.Id == Group.Id);
                            if (preexistingGroup != null)
                                category.Groups.Add(preexistingGroup);
                            else
                                category.Groups.Add(Group);
                        });
                        product.Categories.Add(category);
                    }
                });
                //if the type is alreay in the db use reference to tracked entity pulled from db
                var preexistingType = db.Types.SingleOrDefault(e => e.Id == type.Id);
                if (preexistingType != null)
                    product.Type = preexistingType;
                else
                    product.Type = type;
                //get lists of entities that are to be added to the database, and have been included in the update more than once (causes duplicate key error when attempting to insert).
                var EntitiesToBeInserted = db.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added)
                                     .Where(e => !e.IsRelationship).Select(e => e.Entity).ToList();
                var duplicateGroupInsertions = EntitiesToBeInserted
                                       .OfType<GroupEntity>()
                                       .GroupBy(e => e.Id)
                                       .Where(g => g.Count() > 1)
                                       .SelectMany(g => g.Where(e => e != g.First()));
                var duplicateCategoryInsertions = EntitiesToBeInserted
                                   .OfType<CategoryEntity>()
                                   .GroupBy(e => e.Id)
                                   .Where(g => g.Count() > 1)
                                   .SelectMany(g => g.Where(e => e != g.First()));
                foreach (var category in product.Categories) {
                    //remove duplicate insertions and store references to add back in later
                    var joinedGroups = duplicateGroupInsertions.Join(category.Groups, duplicateGroupInsertion => duplicateGroupInsertion, linkedGroup => linkedGroup, (duplicateGroupInsertion, linkedGroup) => duplicateGroupInsertion);
                    foreach (var duplicateGroupInsertion in joinedGroups) {
                        if (category.Groups.Contains(duplicateGroupInsertion)) {
                            category.Groups.Remove(duplicateGroupInsertion);
                            db.Groups.Detach(duplicateGroupInsertion);
                            duplicateGroupsAdded.Add(new Tuple<CategoryEntity, GroupEntity>(category, duplicateGroupInsertion));
                        }
                    }
                }
                //remove duplicate insertions and store references to add back in later
                var joinedCategories = duplicateCategoryInsertions.Join(product.Categories, duplicateCategoryInsertion => duplicateCategoryInsertion, linkedCategory => linkedCategory, (duplicateCategoryInsertion, linkedCategory) => duplicateCategoryInsertion);
                foreach (var duplicateCategoryInsertion in joinedCategories) {
                    if (product.Categories.Contains(duplicateCategoryInsertion)) {
                        product.Categories.Remove(duplicateCategoryInsertion);
                        db.Categories.Detach(duplicateCategoryInsertion);
                        duplicateCategoriesAdded.Add(new Tuple<ProductEntity, CategoryEntity>(product, duplicateCategoryInsertion));
                    }
                }
                db.SaveChanges();
                //entities not linked to product can now be added using references to the entities stored earlier
                foreach (var duplicateGroup in duplicateGroupsAdded) {
                    var existingCategory = db.Categories.SingleOrDefault(e => e.Id == duplicateGroup.Item1.Id);
                    var existingGroup = db.Groups.SingleOrDefault(e => e.Id == duplicateGroup.Item2.Id);
                    existingCategory.Groups.Add(existingGroup);
                }
                foreach (var duplicateCategory in duplicateCategoriesAdded) {
                    product = db.Products.SingleOrDefault(e => e.Id == duplicateCategory.Item1.Id);
                    var existingCategory = db.Categories.SingleOrDefault(e => e.Id == duplicateCategory.Item2.Id);
                    product.Categories.Add(existingCategory);
                }
                db.SaveChanges();
            }
        }
