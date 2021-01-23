    public class SkinResourceDictionary : ResourceDictionary {
        public static string BaseDirectory { get; set; }
    
    	public new Uri Source {
    		get {
    			return base.Source;
    		}
    		set {
    			base.Source = BaseDirectory + value;
    		}
    	}
    }
