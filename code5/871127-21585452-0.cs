    public class MyEntity
    {
        public virtual int Id { get; set; }
        public virtual MySecondEntity SecondEntity { get; set; }
        
        [ForeignKey( "SecondEntity" )]
        protected virtual int? MySecondEntityId { get; set; }
    
        public void SetSecondEntityId( int? id )
        {
            MySecondEntityId = id;
        }
    }
