    public class A
    {
        public int Id { get; set; }
        public virtual ICollection<B> bCollection { get; set; }
        public void prepareForDelete()
        {
            foreach (var item in bCollection)
            {
                item.RemoveMe();
            }
        }
    }
    public class B
    {
        public int Id { get; set; }
        public event EventHandler Remove;
        public void RemoveMe()
        {
            EventHandler removeHandler = Remove;
            if (removeHandler != null)
            {
                removeHandler(this, EventArgs.Empty);
            }
        }
    }
    public class C2 : BaseClass2
    {
        public int Id { get; set; }
        private B internB;
        // maybe you need an otherform to set B because of your virtual 
        public B B
        {
            get { return internB; }
            set
            {
                if (internB != value)
                    if (internB != null)
                        internB.Remove -= this.RemoveB;
                    else if(value != null)
                        value.Remove += this.RemoveB;
                internB = value;
            }
        }
        public void RemoveB(object sender, EventArgs args)
        {
            internB.Remove -= this.RemoveB;
            B = null;
        }
    }
