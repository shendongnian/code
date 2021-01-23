    public class ComUtil {
    	public static void Release (ref object obj) {
    		if(obj != null) {
    			Marshal.ReleaseComObject(obj);
    		}
    	}
    }
