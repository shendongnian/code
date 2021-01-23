            public Form1()
            {
                InitializeComponent();
                // Create a new Button and set its properties
                myButton = new Button()
                {
                    Location = new System.Drawing.Point(50, 12),
                    Size = new System.Drawing.Size(100, 23),
                    Text = "My Button"
                };
                // Add the Button to the form
                this.Controls.Add(myButton);
                // Add an event handler (the compiler infers the delegate type)
                myButton.Click += WhenClick;
            }
