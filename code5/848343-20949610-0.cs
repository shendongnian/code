    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using MoreLinq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public class HMData     // Dummy HMDta class for test purposes
            {
                public string x { get; set; }
                public string y { get; set; }
                public string z { get; set; }
            }
            static void Main(string[] args)
            {
                var inputItems = new List<int>() { 1, 2, 3, 4 }; // Input items from XML document - dummy test list
    
                // L, I and B value sequences
                var LValues = new List<string>() { "L1", "L2", "L3", "L4", "L5", "L6", "L7", "L8", "L9", "L10", "L11", "L12", "L13", "L14", "L15", "L16", "L17", "L18", "L19", "L20", "L21", "L22", "L23", "L24", "L25", "L26", "L27", "L28" };
                var IValues = new List<string>() { "I1", "I2", "I3", "I4", "I5", "I6", "I7", "I8", "I9", "I10", "I11", "I12", "I13", "I14", "I15", "I16", "I17", "I18", "I19", "I20", "I21", "I22", "I23", "I24", "I25", "I26", "I27", "I28" };
                var BValues = new List<string>() { "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10", "B11", "B12", "B13", "B14", "B15", "B16", "B17", "B18", "B19", "B20", "B21", "B22", "B23", "B24", "B25", "B26", "B27", "B28" };
    
                // Convert our 3 -value sequences into one sequence of HMData objects
                var zippedValues = LValues.Zip(IValues, (lvalue, bvalue) => Tuple.Create(lvalue, bvalue)).Zip(BValues, (pair, bvalue) => new HMData() { x = pair.Item1, y = pair.Item2, z = bvalue });
    
                // Split the sequence into length of length 7
                var batchedValues = zippedValues.Batch(7);
    
                // For each of the inputItems, output a batch from the -value sequences
                // (note we will stop output as soon as either the inputItems or the combined -value sequences are exhausted)
                var data = inputItems.Zip(batchedValues, (item, valueBatch) => valueBatch).ToArray();
    
            }
        }
    }
