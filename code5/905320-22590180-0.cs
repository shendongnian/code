      public int DeleteWhere(Expression<Func<TPoco, bool>> predicate) {
            var delList = GetList(predicate);
            foreach (var poco in delList) {
                Context.Entry(poco).State = EntityState.Deleted;
                          }
            return delList.Count;
            // or Context.SaveChanges... depending on your LUW strategy
        }
