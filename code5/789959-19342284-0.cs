    public class Number { };
    public class Number<T>: Number {};
    public static class NumberGenerator {
       public static Number Generate ( double value ) { return new Number<double>(); }
       public static Number Generate ( int value ) { return new Number<int>(); }
    }
