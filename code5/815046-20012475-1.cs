    class someList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    // and an example instance, should be put in a property if you want to access it from your aspx-code
    var someListObject = new List<someList>()
    {
        new someList() {Id = 1, Name = "#accLstViewInner"},
        new someList() {Id = 2, Name = "#accLstViewInner"},
        new someList() {Id = 3, Name = "#accLstViewInner"},
        new someList() {Id = 4, Name = "#accLstViewInner"},
        new someList() {Id = 5, Name = "#accLstViewInner"}
    };
    
    string jqueryResult = someListObject.Aggregate(string.Empty, (current, item) => current + string.Concat(item.Name, "_", item.Id, item == someListObject.Last() ? string.Empty : ", "));
    // #accLstViewInner_1, #accLstViewInner_2, #accLstViewInner_3, #accLstViewInner_4, #accLstViewInner_5
