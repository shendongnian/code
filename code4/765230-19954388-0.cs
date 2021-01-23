    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace StingComparisons
    {
	[TestClass]
	public class StringComparison
	{
		[TestMethod]
		public void TestMethod1()
		{
			var a = "2.E";
			var b = "2.F";
			var c = "2.C";
			var d = "1.F";
			var e = "3.A";
			StringComparer comp = new MyStringComparer();
			Assert.IsTrue(b.IsSameOrAfter(a, comp));
			Assert.IsFalse(c.IsSameOrAfter(a, comp));
			Assert.IsFalse(d.IsSameOrAfter(a, comp));
			Assert.IsTrue(e.IsSameOrAfter(a, comp));
			Assert.IsTrue(a.IsSameOrAfter(a, comp));
		}
		[TestMethod]
		public void TestMethod2()
		{
			var a = "2.E.1";
			var b = "2.E";
			var c = "2.E.2";
			var d = "2.F";
			var e = "2.D.3";
			var f = "3.A";
			StringComparer comp = new MyStringComparer();
			Assert.IsFalse(b.DotDelimitedIsSameOrAfter(a));
			Assert.IsTrue(c.DotDelimitedIsSameOrAfter(a));
			Assert.IsTrue(d.DotDelimitedIsSameOrAfter(a));
			Assert.IsFalse(e.DotDelimitedIsSameOrAfter(a));
			Assert.IsTrue(f.DotDelimitedIsSameOrAfter(a));
			Assert.IsTrue(a.DotDelimitedIsSameOrAfter(a));
		}
	}
	public static class stringExtensions
	{
                public static bool DotDelimitedIsSameOrAfter(this string a, string b)
                {
                       return a.IsSameOrAfter(b, new MyStringComparer());
                }
		public static bool IsSameOrAfter(this string a, string b, StringComparer comp)
		{
			return comp.Compare(a, b) <= 0;
		}
	}
	public class MyStringComparer : StringComparer
	{
		public override int Compare(string x, string y)
		{
			var partsX = x.Split('.');
			var partsY = y.Split('.');
			for (int i = 0; i < partsY.Length; i++)
			{
				if (partsX.Length <= i)
					return 1;
				var partComp = partsY[i].CompareTo(partsX[i]);
				if (partComp != 0)
					return partComp;
			}
			return 0;
		}
		public override bool Equals(string x, string y)
		{
			return x.Equals(y);
		}
		public override int GetHashCode(string obj)
		{
			return obj.GetHashCode();
		}
	}
    }
