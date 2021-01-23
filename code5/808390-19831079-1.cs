    var builder = new StringBuilder();
    var b1 = (newItems.Aggregate(builder,
                (bld, c) => bld.AppendFormat("\"{0}\",", c),
                bld => bld.Remove(bld.Length - 1, 1))
             ).ToString();
