    ObservableCollection<IEnumerable<Parent>> ManagerListStack = new ObservableCollection<IEnumerable<Parent>>(ManagerTemplates);
    internal static List<IEnumerable<Parent>> ManagerTemplates = new List<IEnumerable<Parent>>
    {
        new ObservableCollection<ChildA>(){},
        new ObservableCollection<ChildB>(){},
    };
    ObservableCollection<U> Get<U>() where U : Parent {
      return (ObservableCollection<U>)ManagerListStack.First(inner => inner is ObservableCollection<U>)
    }
