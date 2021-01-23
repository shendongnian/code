            foreach(object objObject in Controls)
            {
                if (objObject is Button)
                {
                    Button btnObj = (Button)objObject;
                    btnObj.Click += (sender, e) =>
                    {
                        mainTextBox.Clear();
                        btnObj.PerformClick();
                        // how to call the native click button?
                    };
                }
            }
