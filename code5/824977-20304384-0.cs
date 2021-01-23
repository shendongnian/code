    public class Outer
    {
        private int OuterProperty { get; set; }
        public class Inner
        {
            public void UpdateOuter( Outer outer, int value )
            {
                outer.OuterProperty = value;
            }
        }
    }
