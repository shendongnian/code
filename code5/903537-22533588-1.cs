        public abstract class BaseClass {
            protected object _member;
            public object MemberGet { return _member; }
        }
    
        public class InheritClass : BaseClass {
            // now the base class can "decide" to set the member or implement its own set rules
            public static void RoutineThatSetsMember(object value) { _member = value; }
        }
