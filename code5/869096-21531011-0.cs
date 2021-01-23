    public void AddExistingSausage{Sausage sausage}
    {
         var personSausage = new PersonSausage{PersonID = this.ID, SausageID = Sausage.ID};
         this.Sausages.Add(personSausage);
    }
