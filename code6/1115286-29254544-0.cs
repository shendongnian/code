     public class B: A
        {
                public B():base(){
                X = new OverridenInnerOne();
                Y = new OverridenInnerTwo();
                }
                public class OverridenInnerOne: A.InnerOne
                {
                     public override virtual double value(){
                        return 100;
                    }
                }
                public class OverridenInnerTwo: A.InnerTwo
                {
                     public override virtual double value(){
                        return 100;
                    }
                }
        }
