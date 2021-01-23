        public void DeleteSDetails()
        {
            using (Database.dbDataContext context = new Database.dbDataContext(Con_String))
            {
                IQueryable<Database.A> stQuery = from c in context.a select c;
                foreach (var value in stQuery)
                {
                    context.a.DeleteOnSubmit(value);
                }
                context.SubmitChanges();
            }
        }
