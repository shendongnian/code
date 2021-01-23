    var calcd = from t1 in one
                let t2 = two.FirstOrDefault(x => DataMatch(t1, x))
                where t2 != null
                select new {
                    Name = t1.Name,
                    Class = t1.Class,
                    Change = t2.Mark - t1.Mark
                };
    public static bool DataMatch(Data x, Data y)
    {
        return x.Name == y.Name && x.Class == y.Class &&
               x.Term != y.Term && x.Mark  != y.Mark;
    }
