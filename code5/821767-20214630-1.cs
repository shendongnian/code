    public class MyClass
    {
        public MyClass()
        {
            MyColor = Color.Red;
        }
        public Color MyColor { get; set; }
    
        public bool ShouldSerializeMyColor() {  return MyColor != Color.Red; }
    }
