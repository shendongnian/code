    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Test
    {
    	public class CyclicKMP<T> {
    		private readonly IList<T> P;
    		private readonly int[] F;
    		private readonly EqualityComparer<T> comparer;
    
    		public CyclicKMP(IList<T> P) {
    			this.comparer = EqualityComparer<T>.Default;
    			this.P = P;
    			this.F = new int[P.Count+1];
    
    			F[0] = 0;  F[1] = 0;  
    			int i = 1, j = 0;
    			while(i<P.Count) {
    				if (comparer.Equals(P[i], P[j]))
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
    
    			while(i-j <= 2*n-m) {
    				while(j < m) {
    					if (comparer.Equals(P[j], T[i%n])) {
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
    
    	class MainClass
    	{
    		public static bool Check<T>(IList<T> list1, IList<T> list2) {
    			if (list1.Count != list2.Count)
    				return false;
    			return new CyclicKMP<T> (list2).FindAt (list1) != -1;
    		}
    
    		public static void Main (string[] args)
    		{
    			Console.WriteLine (Check(new[]{10, 30, 2, 4, 4}, new[]{4, 4, 10, 30, 2}));
    			Console.WriteLine (Check(new[]{10, 30, 2, 4, 3}, new[]{4, 4, 10, 30, 2}));
    		}
    	}
    }
