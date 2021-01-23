    void Main()
    {
    	var first = "abcabcdefabcabcabcabcdefabcabc".ToList();
    	var second = "abcdefabcabcabcabcdefabcabcabc".ToList();
    
    	var p = new Perf<bool>
    	{
    		{ "AreEqualByRotation", n => AreEqualByRotation (first, second) },
    		{ "IsEqualWithShifting", n => IsEqualWithShifting (first, second) },
    		{ "EqualWithShifting", n => EqualWithShifting (first, second) },
    		{ "CheckIt", n => CheckIt (first, second) },
    	}.Vs("Shifting", 100000);
    }
    
    // Define other methods and classes here
    bool AreEqualByRotation<T> (List<T> s1, List<T> s2)
    {
    	if (s1.Count != s2.Count)
    		return false;
    
    	for (int i=0; i<s1.Count; ++i)
    	{
    		bool res = true;
    		int index = i;
    		for (int j=0; j<s1.Count; ++j)
    		{
    			if (!s1[j].Equals(s2[index]))
    			{
    				res = false;
    				break;
    			}
    			index = (index+1)%s1.Count;
    		}
    		
    		if (res == true)
    			return true;
    	}
    	return false;
    }
    
    bool IsEqualWithShifting<T> (List<T> list1, List<T> list2)
    {
        if (list1.Count != list2.Count) 
            return false;
    
        for (var i = 0; i < list1.Count; i++)
        {
            for (var j = 0; j < list2.Count; j++)
            {
                int countFound = 0;
    
                while (list1[(i + countFound) % list1.Count].Equals(list2[(j + countFound) % list2.Count]) && countFound < list1.Count)
                    countFound++;
    
                if (countFound == list1.Count)
                    return true;
            }
        }
    
        return false;
    }
    
    public static IEnumerable<T> Shift<T>(IEnumerable<T> source, int number)
    {
        return source.Skip(number)
            .Concat(source.Take(number));
    }
    
    public static bool EqualWithShifting<T>(IList<T> first, IList<T> second)
    {
        return first.Count == second.Count &&
            Enumerable.Range(0, first.Count-1)
            .Any(shift => first.SequenceEqual(Shift(second, shift)));
    }
    
    public class KMP<T> {
       private readonly IList<T> P;
       private readonly int[] F;
    
       public KMP(IList<T> P) {
           this.P = P;
           this.F = new int[P.Count+1];
    
           F[0] = 0;  F[1] = 0;  
           int i = 1, j = 0;
           while(i<P.Count) {
               if (Object.Equals(P[i], P[j]))
                   F[++i] = ++j;
               else if (j == 0)
                   F[++i] = 0;
               else
                   j = F[j];
           }
       }
    
       public int FindAt(IList<T> T, int start=0) {
           int i = start, j = 0;
           int n = T.Count, m = P.Count;
    
           while(i-j <= n-m) {
               while(j < m) {
                   if (Object.Equals(P[j], T[i])) {
                       i++; j++;
                   } else break;
               }
               if (j == m) return i-m;
               else if (j == 0) i++;
               j = F[j];
           }
           return -1;
       }
    }
    
    public static bool CheckIt<T> (IList<T> list1, IList<T> list2)
    {
    	return Check (list1, list2) != -1;
    }
    
    public static int Check<T>(IList<T> list1, IList<T> list2)
    {
    	if (list1.Count != list2.Count)
    		return -1;
    	return new KMP<T> (list2).FindAt (new List<T>(Enumerable.Concat(list1, list1)));
    }
