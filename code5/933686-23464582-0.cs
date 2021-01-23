    namespace ABC {
        [BaseType (typeof (NSObject))]
        public partial interface ClassAbc {
            [Export ("setString:")]
            void SetString (string abc);
        }
    }
    namespace ABCUsage {
        [BaseType (typeof (NSObject))]
        public partial interface ClassAbcUsage {
            [Export ("setAbc:")]
            void SetAbc (ABC.ClassAbc abc);
                        //^^^^^
        }
    }
