    public class Square : Shape {
        public override string GetName() { // Note, same name
            return "Square";
        }
    }
    // ... other classes overriding the method here ...
    while (true) {
        foreach (Shape s in list) {
            render(s.GetName());
        }
    }
    
