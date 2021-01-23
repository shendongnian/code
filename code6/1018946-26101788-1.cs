    public class ColorCode : DescriptedCodeValue
    {
        private ColorCode(int id, string description) : base(id, description) { }
        public static ColorCode Red = new ColorCode(1, "#ff0000");
        public static ColorCode Green = new ColorCode(2, "#00ff00");
    }
