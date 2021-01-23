    public class CertainClass
    {
        private class ProtectedClass
        {
            public static void ProtectedFunction()
            {
                Debug.Log("Protected");
            }
        }
        public void CerFunc()
        {
            ProtectedClass.ProtectedFunction();
        }
    }
