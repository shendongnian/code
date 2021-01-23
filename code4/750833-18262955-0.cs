    public class AppRespository
    {
        private DataContext db = new DataContext();
    
        public IEnumerable<SelectListItem> LoadStates()
        {
            var query = from d in db.States.ToList()
                        select new SelectListItem
                        {
                            Value = d.StateID.ToString(),
                            Text = d.State
                        };
            return query;
        }
    }
