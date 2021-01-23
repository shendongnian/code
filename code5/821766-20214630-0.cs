    public class MyClass
    {
        public MyClass()
        {
            ResetMyColor();
        }
        public Color MyColor { get; set; }
    
        private bool ShouldSerializeMyColor() {  return MyColor != Color.Red; }
        private void ResetMyColor() { MyColor = Color.Red; }
    }
