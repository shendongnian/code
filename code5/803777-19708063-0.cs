    public class TDtoWrapper
    {
        public DateTime SortKey {get;set; }
        public Object Member {get;set;}
    }
    var result1 = from c in combo1
                  select new TDtoWrapper { SortKey = c.ctime, Member = c }
    var result2 = from c in combo2
                  select new TDtoWraller { SortKey = c.startedfollowing, Member = c }
    var result = result1.Concat(result2).Orderby(x => x.SortKey).Select(x => x.Member);
