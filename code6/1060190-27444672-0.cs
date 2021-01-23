    public class ScriptA : MonoBehaviour {
    public int[] keys = new int[4];
    public int[] screws= new int[4];
    public int[] nails= new int[4];
    public int[] iron= new int[4];
    public Dictionary<string, int[]> arrays = new Dictionary<string, int[]>
        {
            { "keys", keys },
            { "screws", screws },
            { "nails", nails },
            { "iron", iron }
        };
    }
