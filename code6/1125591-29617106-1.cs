    class Grid
    { }
    class Stack
    { }
    abstract class Location
    {
        private Location() {}
        
        public class GridLocation : Location
        {
            public Grid Grid { get; set; }
            
            public int X { get; set; }
            
            public int Y { get; set; }
        }
        public class StackLocation : Location
        {
            public Stack Stack { get; set; }
            
            public int Position { get; set; }
        }
    }
    abstract class Visual
    {
        
    }
    class Block
    {
        public Visual Visual { get; set; }
        
        public Location.GridLocation Location { get; set; }
    }
    class Card
    {
        public Visual Visual { get; set; }
        public Location.StackLocation Location { get; set; }
    }
    class Counter
    {
        public Visual Visual { get; set; }
        public Location Location { get; set; }
    }
    class Game
    {
        public IEnumerable<Block> Blocks { get; set; }
        
        public IEnumerable<Card> Cards { get; set; }
        
        public IEnumerable<Counter> Counters { get; set; }
        
        public IEnumerable<Tuple<Location.StackLocation, Visual>> StackVisuals
        {
            get
            {
                var cardVisuals =
                    Cards.Select (c => Tuple.Create(c.Location, c.Visual));
                    
                var counterVisuals =
                    Counters.Select (c => Tuple.Create(c.Location, c.Visual))
                    .OfType<Tuple<Location.StackLocation, Visual>>();
                    
                return cardVisuals.Concat(counterVisuals).OrderBy (v => v.Item1.Position);
            }
        }
        
        public IEnumerable<Tuple<Location.GridLocation, Visual>> GridVisuals
        {
            get
            {
                var blockVisuals =
                    Blocks.Select (b => Tuple.Create(b.Location, b.Visual));
                    
                var counterVisuals =
                    Counters.Select (c => Tuple.Create(c.Location, c.Visual))
                    .OfType<Tuple<Location.GridLocation, Visual>>();
                    
                return blockVisuals.Concat(counterVisuals).OrderBy (v => new { v.Item1.X, v.Item1.Y });
            }
        }
    }
