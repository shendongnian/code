        public class MyClass
        {
           public int Number {get; set;};
           public string Text {get; set;}
        }
        var list2d = new List<MyClass>();
        list2d.Add(new MyClass() { Number = 1, Text = "hello" });
        list2d.Add(new MyClass() { Number = 2, Text = "world" });
        foreach (var item in lists2d)
        {
            Console.WriteLine(string.Format("{0}: {1}", item.Number, item.Text);
        }
