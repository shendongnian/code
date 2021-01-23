            public Form1()
            {
                InitializeComponent();
                myButton = new Button()
                {
                    Location = new System.Drawing.Point(50, 12),
                    Size = new System.Drawing.Size(100, 23),
                    Text = "My Button"
                };
                
                this.Controls.Add(myButton);
                myButton.Click += WhenClick;
            }
