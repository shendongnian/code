    private void LoadData(int iPersonID)
    {
       using (PeopleEntities ctx = new PeopleEntities())
       {
          // AsNoTracking will avoid performance hit of change-tracking here...
          // Since we're building-up a view, not an update case yet, you don't have to create
          // proxies that will check for entity changing...
          var query = ctx.People.AsNoTracking().SingleOrDefault(_people => _people.PersonID == iPersonID)
          // Rendering comes into action
          if (query != null)
          {
             TextBoxFirstName.Text = query.FirstName;
             TextBoxLastName.Text = query.LastName;
          }
       }
    }
    private void SaveEmployee(int iPersonID = 0)
    {
       using (PeopleEntities ctx = new PeopleEntities())
       {  
          var query = ctx.Prople.SingleOrDefault(_person => _person.PersonID == iPersonID);
          if (query != null)
          {
             query.FirstName = TextBoxFirstName.Text;
             query.LastName = TextBoxLastName.Text;
             ctx.SaveChanges();
          }
       }
    }
