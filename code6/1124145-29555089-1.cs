    public Customer Get(Expression<Func<Customer, bool>> where)
    {
      var addGroup = groupRepository.Get(EntityType.Customer).AddGroup;
      if (addGroup) {
        return new UserSpecificCustomerRepository(user, customerRepository).Get(where);
      }
      return customerRepository.Get(where);
    }
