    class IntLabel : Label
    {
        int val;
        public int Value 
        {
            get { return val; }
            set { val = value; Text = val.ToString(); }
        }
        public IntLabel()
        {
            Font = new Font("Consolas", 15f);
            BackColor = Color.Brown;
            ForeColor = Color.AntiqueWhite;
            TextAlign = ContentAlignment.MiddleCenter;
            //..
        }
        public IntLabel(int val, string name) : base()
        { 
            Value = Value; 
            Name = name;
        }
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            AutoSize = false;
            Size = new System.Drawing.Size(120, 30);
        }
        public int Add(int n)
        {
            Value += n;
            Text = Value.ToString();
            return Value;
        }
    }
