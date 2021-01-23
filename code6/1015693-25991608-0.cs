    List<string> list = new List<string>();
    list.add("2.2");
    list.add("2.5");
    list.add("2.6");
    list.add("2.2");
    list.add("2.5");
    list.add("2.2");
    list.RemoveAll(item => item == "2.2");
