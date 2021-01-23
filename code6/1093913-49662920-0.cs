    public class MyBigObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public string TypeId { get; set; }
        [Computed]
        public bool IsFoo 
        { 
            get { /* complicated logic here for checking if TypeId IsFoo */ }
        }
        [Computed]
        public bool IsBar 
        { 
            get { /* complicated logic here for checking if TypeId IsBar */ }
        }
    
        /* snip about 30 other columns */
    }
