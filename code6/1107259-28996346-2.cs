    // at the beginning of your method
    Contract.Requires(MyCollection != null && Contract.ForAll(MyCollection, x => x != null));
    // other code
    foreach(var item in MyCollection)
    {
       Contract.Assume(item != null);
       // call method on item which can create a message from the static checker if the assume is not included
    }
