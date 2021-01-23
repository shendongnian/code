    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace UnitTestProject1
    {
        public enum InstrType
        {
            HydraSbs,           // = 0
            HydraLbs,           // = 1
            HydraSfs,           // = 2
            HydraLfs,           // = 3
            HydraEconomique,    // = 4
            Blind,              // = 5
            Lxio,               // = 6
            Sxio,               // = 7
            Sfse,               // = 8
            T800QVga,           // = 9
            T800SVGa,           // = 10
            Eycon10,            // = 11
            Eycon20,            // = 12
            T2550,              // = 13
            T2750,              // = 14
            Nanodac             // = 15
        }
        public class HistoryRecord
        {
            public InstrType InstructionType { get; set; }
            public HistoryRecord(InstrType instructionType)
            {
                //NOTE: Possible bug here
                //We could possibly be missing this assignment perhaps:
                //InstructionType = instructionType;
            }
        }
        [TestClass]
        public class UnitTest1
        {
            /// <summary>
            /// This method should pass
            /// </summary>
            [TestMethod]
            public void TestMethod1()
            {
                var myVal = InstrType.Nanodac;
                Assert.AreEqual(InstrType.Nanodac, myVal);
            }
            /// <summary>
            /// This method should fail with -> Expected:<Nanodac>. Actual:<HydraSbs>
            /// </summary>
            [TestMethod]
            public void TestMethod2()
            {
                // Please check the 'HistoryRecord' class above for the possible error
                // Here the the value of InstructionType has not actually been set yet, so will default to 0 in the underlying datatype (int)
                // In this case that underlying 0 value will be mapped to the first enum value which is HydraSbs
                // that is why you'd get the error -> Expected:<Nanodac>. Actual:<HydraSbs>
                var historyRecord = new HistoryRecord(InstrType.Nanodac);
                var myVal = historyRecord.InstructionType;
                var intValue = (int)myVal;
                Assert.AreEqual(0, intValue);
                Assert.AreEqual(InstrType.Nanodac, myVal); 
            }
        }
    }
