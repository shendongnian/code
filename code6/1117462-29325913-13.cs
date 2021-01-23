    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Numerics;
    
    
    [TestClass]
    public class UnitTestComputation
    {
        [TestMethod]
        public void TestFactorial()
        {
            Assert.AreEqual(1, Program.Factorial(0));
            Assert.AreEqual(1, Program.Factorial(1));
            Assert.AreEqual(2, Program.Factorial(2));
            Assert.AreEqual(6, Program.Factorial(3));
            Assert.AreEqual(24, Program.Factorial(4));
        }
    
        [TestMethod]
        public void TestSeries()
        {
            int k = 1;
            int p = 1;
            BigRational expected = 1;
            Assert.AreEqual(expected, Program.Series(k, p));
    
            k = 2;
            p = 1;
            expected += 1;
            Assert.AreEqual(expected, Program.Series(k, p));
    
            k = 3;
            p = 1;
            expected += (BigRational)1 / (BigRational)2;
            Assert.AreEqual(expected, Program.Series(k, p));
    
            k = 1;
            p = 2;
            expected = 1;
            Assert.AreEqual(expected, Program.Series(k, p));
    
            k = 2;
            p = 2;
            expected += 2;
            Assert.AreEqual(expected, Program.Series(k, p));
        }
    
        [TestMethod]
        public void TestP()
        {
            int n = 1;
            int k = 2;
            int p = 1;
            // P(0) = 1 / (2 + 1/(2*(1 - 1/2))) = 1/3
            // P(1) = (1/(1/2 * 2)) * P(0) = P(0) = 1/3 
            BigRational expected = 1;
            expected /= 3;
            Assert.AreEqual(expected, Program.ComputeP(k, n, p));
    
            n = 2;
            k = 2;
            p = 1;
            // P(2) = (1/(1*2)) * P(0) = 1/6
            expected = 1;
            expected /= 6;
            Assert.AreEqual(expected, Program.ComputeP(k, n, p));
        }
    }
