    public class RadioButtonBox:ListBox
    {
        public readonly RadioButtonBoxPainter Painter;
        public RadioButtonBox()
        {
            Painter = new RadioButtonBoxPainter(this);
        }
        [DefaultValue(DrawMode.OwnerDrawFixed)]
        public override DrawMode DrawMode
        {
            get{return base.DrawMode;}
            set{base.DrawMode = value;}
        }
    }
