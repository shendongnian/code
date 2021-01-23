    IEnumerable<Parent> parents = ...;
    var parentsWithChildren = parents.GroupJoin(children,
                                                c => c.ParentName,
                                                c => c.ParentName,
                                                (a, b) => new
                                                          {
                                                              Parent = a,
                                                              ChildNames = b.Select(x => x.ChildName)
                                                          });
    foreach (var v in parentsWithChildren)
    {
        v.Parent.ChildNames = v.ChildNames;
    }
