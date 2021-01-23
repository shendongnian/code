    ObservableCollection<IEnumerable<Parent>> ManagerListStack = new ObservableCollection<IEnumerable<Parent>>(ManagerTemplates);
    internal static List<IEnumerable<Parent>> ManagerTemplates = new List<IEnumerable<Parent>>
    {
        new IEnumerable<ChildA>(){},
        new IEnumerable<ChildB>(){},
    };
    IEnumerable<U> Get<U>() where U : Parent {
      return ManagerListStack.First(inner => inner is IEnumerable<U>)
    }
