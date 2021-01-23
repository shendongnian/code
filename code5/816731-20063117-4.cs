    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace LinqToObjects
    {
    	class Custom
    	{
    		public int Qid { get; set; }
    		public int Uid { get; set; }
    		public DateTime Date { get; set; }
    		public double BS { get; set; }
    	}
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			List<Custom> lst = new List<Custom>()
    			{
    				new Custom(){ Qid=1, Uid=1, Date=new DateTime(2013,9,12) ,BS=0.5},
    				new Custom(){ Qid=1, Uid=2, Date=new DateTime(2013,9,13) ,BS=0.8},
    				new Custom(){ Qid=1, Uid=2, Date=new DateTime(2013,9,14) ,BS=0.5},
    				new Custom(){ Qid=1, Uid=2, Date=new DateTime(2013,9,15) ,BS=0.9},
    				new Custom(){ Qid=2, Uid=1, Date=new DateTime(2013,9,12) ,BS=0.75},
    				new Custom(){ Qid=2, Uid=1, Date=new DateTime(2013,9,13) ,BS=0.8},
    				new Custom(){ Qid=2, Uid=2, Date=new DateTime(2013,9,12) ,BS=0.75}
    			};
    
    			var query = lst.GroupBy(obj => new { obj.Qid, obj.Uid}, ( key,group) => new {Key1= key.Qid, Key2 = key.Uid, Avg = group.Average(o=>o.BS), lst = group});
    
    			Console.WriteLine("Qid\tUid\tWeightedAvg");
    			foreach(var item in query)
    			{
    				double weightAvg=0;
    				int cnt = 0;
    				foreach (var i in item.lst)
    				{
    					weightAvg += i.BS * (Math.Pow(1.25, cnt++));
    				}
    
    				weightAvg /= item.lst.Count();
    
    				Console.WriteLine(string.Format("{0}\t{1}\t{2}", item.Key1, item.Key2, weightAvg)) ;
    			}
    
    		}
    	}
    }
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace LinqToObjects
    {
    	class DateComparer : IEqualityComparer<Custom>
    	{
    
    		public bool Equals(Custom x, Custom y)
    		{
    			if (Object.ReferenceEquals(x.Date, y.Date)) return true;
    
    			return false;
    		}
    
    		public int GetHashCode(Custom obj)
    		{
    			if (Object.ReferenceEquals(obj, null)) return 0;
    
    			int hashCode = obj.GetHashCode();
    
    			return  hashCode;
    		}
    	}
    }
