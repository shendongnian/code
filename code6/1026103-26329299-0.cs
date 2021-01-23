    f2.Closed += (s, e) =>
        {
            MessageBox.Show(f2.FirstName);
            nameLabel.Text = f2.FirstName;
            // another action
            // yet another action
        };
