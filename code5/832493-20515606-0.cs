    class B : IDisposable {
        private classA cA;
        public B() {
          cA = new classA();
        }
        public void Dispose() {
            if (cA != null) {
               cA.Dispose();
               cA = null;
            }
        }
    }
