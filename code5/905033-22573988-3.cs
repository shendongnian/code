    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		decimal[] array = new decimal[5]{80.23M,80.40M,80.80M,80.00M,20.45M};
    		decimal TargetNumber = 70.40M;
    		
    		var result = FindClosestIndex(TargetNumber, array, (target, element) => Math.Abs(target - element));
    		
    		Console.WriteLine(result);
    	}
    	
    	public static int FindClosestIndex<T,U>(T target, IEnumerable<T> elements, Func<T,T,U> distanceCalculator) where U : IComparable<U>
    	{
    		U minDistance = default(U);
    		int minIndex = -1;
    		
    		using(var enumerator = elements.GetEnumerator())
    		for(int i = 0; enumerator.MoveNext(); i++)
    		{
    			
    			var distance = distanceCalculator(enumerator.Current, target);
    			if(minIndex == -1 || minDistance.CompareTo(distance) > 0)
    			{
    				minDistance = distance;
    				minIndex = i;
    			}
    		}
    		
    		return minIndex;
    	}
    }
