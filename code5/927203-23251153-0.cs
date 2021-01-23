    var peopleList = new List<Person>();
    peopleList.Add(new Person() { Name = "Joe", Id = 30 });
    peopleList.Add(new Person() { Name = "Tom", Id = 22 });
    peopleList.Add(new Person() { Name = "Jack", Id = 62 });
    var list = new List<int>();
    list.Add(22);
    list.Add(62);
    list.Add(30);
    peopleList.Sort((x, y) => list.IndexOf(x.Id).CompareTo(list.IndexOf(y.Id)));
