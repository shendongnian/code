    List<Class1> list1 = new List<Class1>();
    Class1 o1 = new Class1(1, TypeEnum.E1);
    Class1 o2 = new Class1(2, TypeEnum.E1);
    Class1 o3 = new Class1(3, TypeEnum.E2);
    list1.Add(o1);
    list1.Add(o2);
    list1.Add(o3);
    var count = list1.Select(o => o.Eobj).Distinct().Count();
