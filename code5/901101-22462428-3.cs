    class Order {
        public virtual double GetValue() { ... }
    }
    
    class OrderA : Order { 
        public double X; 
        public override double GetValue() { return this.X; }
    }
    
    class OrderB : Order { 
        public double X; 
        public override double GetValue() { return this.X; }
    }
    
    class OrderC : Order { 
        public double Y; 
        public override double GetValue() { return this.Y; }
    }
    ...
    private DoSomething(Order order)
    {
        double myValue = order.GetValue();
        // DO SOMETHING MORE
    }
