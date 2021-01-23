     class Parent
        {
            public virtual void Add(string msg)
            {
                System.Windows.Forms.MessageBox.Show("Parent got msg");
            }
        }
    
        class child1:Parent
        {
            public override void Add(string msg)
            {
                System.Windows.Forms.MessageBox.Show("Child 1 Got Msg");
            }
        }
    
        class child2 : Parent
        {
            public override void Add(string msg)
            {
                System.Windows.Forms.MessageBox.Show("Child 2 Got Msg");
            }
    
        } 
