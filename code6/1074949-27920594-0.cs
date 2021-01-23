    var names = new[] {"Alex", "Anna"};
    var ages = new[] {19, 20}
    var grades = new[] {"A", "B"}
    var students = names.Zip(ages, (n, a) => Tuple.Create(n, a))
                        .Zip(grades, (t, g) => new Student(t.Item1, t.Item2, g));
