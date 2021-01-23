            List<Control> radioButtons = new List<Control>();
            var cacheNames = GetCacheNames();
            var location = new Point(0,0);
            //Lets load cache names to cachesRadioButtonsPanel
            foreach (var cacheName in cacheNames)
            {
                RadioButton radiobutton = new RadioButton();
                radiobutton.Name = cacheName;
                radiobutton.Text = cacheName;
                radiobutton.Location = location;
                radioButtons.Add(radiobutton);
                location.Y = location.Y + radiobutton.Height;
            }
            foreach (var singleControl in radioButtons)
            {
                cachesRadioButtonsGroupBox.Controls.Add(singleControl);
            }  
