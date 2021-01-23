    public class Person
    {
        IList<PersonRelation> _sons;
        IList<PersonRelation> _daughters;
        ..,
        public virtual IList<PersonRelation> Sons 
        {
            get { return _sons ?? (_sons = new List<PersonRelation>()); }
            set { _sons = value; }
        }
        public virtual IList<PersonRelation> Daughters
        {
            get { return _daughters?? (_daughters= new List<PersonRelation>()); }
            set { _daughters= value; }
        }
    }
