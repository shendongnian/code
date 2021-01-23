        Button button1 = new Button(), button2 = new Button();
        button1.Click += new EventHandler(button1_Click);
        button2.Click += new EventHandler(button2_Click);
        
        void button1_Click(object sender, EventArgs e)
        {
            /* .................... */
            button2.PerformClick(); //Simulate click on button2
            /* .................... */
        }
        void button2_Click(object sender, EventArgs e)
        {
            /* .................... */
        }
