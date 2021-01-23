        public IQueryable<Item> FilterItems(IQueryable<Item> items)
        {
            string searchString = txtSearchString.Text.ToUpper();
            Expression<Func<Item, bool>> predicate;
            switch (Field)
            {
                case SearchField.Brand:
                default:
                    predicate = BuildBrandPredicate(searchString);
                    break;
                case SearchField.Model:
                    predicate = BuildModelPredicate(searchString);
                    break;
                case SearchField.Note:
                    predicate = BuildNotePredicate(searchString);
                    break;
                case SearchField.Reference:
                    predicate = BuildReferencePredicate(searchString);
                    break;
                case SearchField.Text:
                    predicate = BuildTextPredicate(searchString);
                    break;
            }
            var result = items.Where(predicate);
            return result;
        }
        private Expression<Func<Item, bool>> BuildBrandPredicate(string searchString)
        {
            Expression<Func<Item, bool>> predicate;
            //build the predicate for brand
            switch (cboSearchActions.Text)
            {
                case "Exact":
                    predicate = (item => item.Brand.Description.ToUpper() == searchString);
                    break;
                //Other similar functions go here but I am concentrating on Exact
            }
            return predicate;
        }
