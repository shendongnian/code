        public class TestClass
        {
            private readonly double _p1;
            private readonly double _p2;
            public TestClass( double p1 , double p2 )
            {
                _p1 = p1;
                _p2 = p2;
            }
            public void TestFunction( /* use other parameters specifc for this method*/ )
            {
                // use  your fields here
                var p1 = _p1;
                var p2 = _p2;
            }
        }
