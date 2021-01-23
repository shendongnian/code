    using System.Linq; // Make sure you include this line
    public int[] Find_Common_Elements(int[] p1, int[] p2)
    {
        return p1.Intersect(p2).ToArray();
    }
