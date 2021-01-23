    class Member {
        public string CategoryId {get; set;}
        public string MemberName{get; set;}
        public int Distance{get; set;}
    }
	var list = new List<Member>();
	list.Add(new Member{ CategoryId = "01", MemberName="andy", Distance=3});
	list.Add(new Member{ CategoryId = "02", MemberName="john", Distance=5});
	list.Add(new Member{ CategoryId = "01", MemberName="mathew", Distance=7});
	list.Add(new Member{ CategoryId = "03", MemberName="bakara", Distance=2});
	var query = list.GroupBy(member => member.CategoryId).Select(x=>x.OrderBy(y=>y.Distance).First());
