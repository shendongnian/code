    public abstract class View
    {   
        public string Id { get; set; }
    }
    
    public class ImageView : View
    {
        public Image Image { get; set; }
    }
    
    public class BarcodeView : View
    {
        public Barcode Barcode { get; set; }
    }
    
    public class TextView : View
    {
        public Text Text { get; set; }
    }
