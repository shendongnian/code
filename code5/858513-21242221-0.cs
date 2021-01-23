        public class IDDesc : IComparable<IDDesc>
        {    
            public int ID { get; set; }
            public string Description { get; set; }
    
            public int CompareTo(IDDesc other)
            {
            //     A value that indicates the relative order of the objects being compared.
            //     The return value has the following meanings: Value Meaning Less than zero
            //     This object is less than the other parameter.Zero This object is equal to
            //     other. Greater than zero This object is greater than other.
                 int ret = -1;
                 if (this.ID > other.ID)
                     ret = 1;
                 else if (this.ID == other.ID)
                     ret = 0;
    
                 return ret;
            }
        }
