    public class FooModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
  
    var temp = new FooModel[] 
    {
        new FooModel {Id = 1, Text = "Mr"}, new FooModel {Id = 2, Text = "Miss"},
        new FooModel {Id = 3, Text = "Ms"}, new FooModel {Id = 4, Text = "Mrs"}
                           };
    ViewBag.TitleList = new SelectList(temp, "Id", "Text", 2);
