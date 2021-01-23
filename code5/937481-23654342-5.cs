    public IListEx<Model.Address> LoadAddresses(QueryMethodParameter p)
    {
      ICriteria ca = this.ServiceFactory.CreateCriteria(this.Context, typeof(Model.Address));
      ICriteria ma = null;
      for (int i = 0; i < p.Items.Count; i++)
      {
        object val = p.Items[i].Value;
        if (val == null)
        {
          throw new NullReferenceException();
        }
        if (val.GetType() == typeof(string))
        {
          if (!val.ToString().EndsWith("%"))
          {
            val = val.ToString() + "%";
          }
          if (!val.ToString().StartsWith("%"))
          {
            val = "%" + val.ToString();
          }
        }
        if (p.Items[i].ModelName == "Address")
        {
          ca.Add(Expression.Like(p.Items[i].PropertyName, val));
        }
        else if (p.Items[i].ModelName == "MailingAddress")
        {
          if (ma == null)
          {
            ma = ca.CreateCriteria("MailingAddress", "MailingAddress");
          }
          ma.Add(Restrictions.Like(p.Items[i].ModelName + "." + p.Items[i].PropertyName, val));
        }
        else
        {
          throw new NotImplementedException();
        }
      }
      ca.Add(Expression.Gt("AddressID", 0));
      return ca.ListEx<Model.Address>();
    }
