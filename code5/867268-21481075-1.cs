    public class A {
        private B _referenceB;
        private C _referenceC;
        public int Id { get; set; } 
        public string Name { get; set; }
        public virtual B ReferenceB {
            get { return _referenceB; }
            set { 
                    if (this.ReferenceC != null) {
                       throw new InvalidOperationException();
                    }
                    _referenceB = value;
                }
            }
        public virtual C ReferenceC {
            get { return _referenceC; }
            set { 
                    if (this.ReferenceB != null) {
                       throw new InvalidOperationException();
                    }
                    _referenceC = value;
                }
            }
        }
    }
