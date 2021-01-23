    public class SomeModel {
        [AllowHtml]
        public string Selected_Nme { get; set; }
        // this property will still be validated!
        public string PleaseDontXSSMe { get; set; }
    }
