    public DomainClassAdapter(Contract.ClassA input)
    {
      _input = input;
      this.Members = _input.Members.Select(x => new DomainListMemberAdapter(x));
    }
