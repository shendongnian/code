        foreach (var pair in FailedMonitorings)
        {
            var server = (ServerEnum)pair.Key;
            var tabPanel = new TabPanel { HeaderText = server.GetDescription() };
            var updatePanel = new UpdatePanel();
            var upChilds = updatePanel.ContentTemplateContainer.Controls;
            var label = new Label { Text = "Hello from UP-" + tabPanel.HeaderText, ID = "lbl" + tabPanel.HeaderText};
            upChilds.Add(label);
            const string command = @"changeText('{0}')";
            var button = new Button {Text = "Button"};
            upChilds.Add(button);
            tabPanel.Controls.Add(updatePanel);
            tbcErrors.Tabs.Add(tabPanel);
            button.OnClientClick = string.Format(command, label.ClientID);
        }
