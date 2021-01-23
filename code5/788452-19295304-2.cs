            public void CheckSelection()
        {
            if (tabControlDbSwitch.InvokeRequired)
            {
                tabControlDbSwitch.Invoke(new Action(() => { CheckTabSelection(); }));
            }
            else
                CheckTabSelection();
        }
        public void CheckTabSelection()
        {
            if (tabControlDbSwitch.SelectedIndex == 0)
            { 
                // Do my work .....
            }
        }
