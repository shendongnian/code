    public class SomeModel {
        [AllowHtml]
        public string Selected_Nme { get; set; }
        //This property will still be validated!
        pubic string PleaseDontXSSMe { get; set; }
    }
