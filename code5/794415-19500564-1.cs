Install()
     public override void Install(IDictionary stateSaver)
            {
                base.Install(stateSaver);
    
                Form1 form = new Form1();
                form.ShowDialog();
            }
