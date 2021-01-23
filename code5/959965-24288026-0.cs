    public class TestObject
    {
         public TestObject(string expected, int in1, int in2)
         {
             Expected = expected;
             In1 = in1;
             In2 = in2;
         }
         public string Expected { get; set; }
         public int In1 { get; set; }
         public int In2 { get; set; }
         public override string ToString()
         {
             return string.Format("In1: {0}, In2: {1}", In1, In2);
         }
    }
