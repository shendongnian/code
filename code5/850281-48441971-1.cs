        public class Foo
        {
           public Bar Bar { get; set; }
           public string FooBar { get; set; }
        public override bool Equals(object obj)
        {
            var foo = obj as Foo;
            return foo != null &&
                   EqualityComparer<Bar>.Default.Equals(Bar, foo.Bar) &&
                   FooBar == foo.FooBar;
        }
        public override int GetHashCode()
        {
            var hashCode = 181846194;
            hashCode = hashCode * -1521134295 + EqualityComparer<Bar>.Default.GetHashCode(Bar);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FooBar);
            return hashCode;
        }
  
    }
