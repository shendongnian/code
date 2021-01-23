    public class Phones : ICloneable
        {
            public int ID { get; set; }
            public string Phone { get; set; }
            public bool isChild { get; set; }
            public object Clone()
            {
                return new Phones()
                {
                    ID = this.ID,
                    Phone = this.Phone,
                    isChild = this.isChild
                };
            }
        }
