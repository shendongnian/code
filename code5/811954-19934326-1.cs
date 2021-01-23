    foreach (var business in GlobalClass.Businesses)
    {
         var linkLabel = new LinkLabel { Text = business.businessName.ToString(), Tag = business };
         linkLabel.Click += MyLinkClick;
         tableLayoutPanel.Controls.Add(linkLabel);
    }
