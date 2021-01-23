    var a = new Skill {Id =0, Name="test"};
    var b = new Skill {Id =2, Name="test"};
    var c = new Skill {Id= 1, Name="test" };
    var d = new Skill { Id = 3, Name = "foo" };
    var e = new Skill { Id = 0, Name = "foo" };
    var listA = new List<Skill> { a, b };
    var listB = new List<Skill> { c, d, e };
    var result = listA.Concat(listB).OrderByDescending(s => s.Id).Distinct(new SkillComparer());
    foreach (var skill in result)
    {
        Console.WriteLine(string.Format("{0}: {1}", skill.Name, skill.Id));
    }
