    public class Foo<T>
    {
        private class Private2 : Private1
        { }
        private class Private1
        {
            public sealed class Nested
            {
                public void Test( Foo<T> foo )
                {
                    foo.Method2( this ); //Yup
                    var nes = (Private2.Nested)this; //Yup
                }
            }
        }
        public void Method1()
        {
            var nested = new Private2.Nested();
            nested.Test( this );
        }
        private void Method2( Private2.Nested nested )
        {
            // something code...
        }
    }
