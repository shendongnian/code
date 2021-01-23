    class A {
        B x, y, z;
        
        void Init() {
            x.Something += Common;
            y.Something += Common;
            z.Something += Common;
        }
        
        void Common(object sender, EventArgs e) {
            
        }
    }
    class B {
        public event EventHandler Something;
        
        public void OnSomething() {
            if (Something != null)
                Something(this, EventArgs.Empty);
        }
    }
