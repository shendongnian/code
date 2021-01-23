    using System;
    using System.Collections.Generic;
    
    namespace WpfTestBench
    {
        public partial class GraphicSample
        {
            public GraphicSample()
            {
                InitializeComponent();
    
                DataContext = new GraphicContext();
            }
        }
    
        public class GraphicContext
        {
            private readonly Random _random = new Random();
    
            public GraphicContext()
            {
                Rows = new List<Row>();
    
                for (var i = 1; i <= 4; i++)
                    Rows.Add(new Row(_random, i));
            }
    
            public IList<Row> Rows { get; set; }
        }
    
        public class Row
        {
            private const int Size = 16;
    
            public Row(Random random, int id)
            {
                Id = id;
                Squares = new List<Square>();
    
                for (var i = 0; i < Size; i++)
                    Squares.Add(new Square(random.Next(20)));
            }
    
            public int Id { get; private set; }
            public IList<Square> Squares { get; private set; }
        }
    
        public class Square
        {
            public Square(int value)
            {
                Value = value;
            }
    
            public int Value { get; set; }
        }
    }
