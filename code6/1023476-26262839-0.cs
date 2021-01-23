    public class InactiveUsersController : ViewController
    {
        public InactiveUsersController()
        {
            this.TargetViewNesting = Nesting.Any;
            this.TargetViewType = ViewType.ListView;
            this.TargetObjectType = typeof(Buyer);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ListView listView = View as ListView;
            listView.CollectionSource.Criteria.Remove("InactiveUserFilter"); // clear the filter
            var currentUser = SecuritySystem.CurrentUser as ExtendedSecuritySystemUser;
            if (!currentUser.Active)
            {
                // return empty list if user is inactive
                listView.CollectionSource.Criteria.Add("InactiveUserFilter", CollectionSource.EmptyCollectionCriteria); 
            }
        }
    }
