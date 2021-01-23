    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (Keyboard.Modifiers == ModifierKeys.Control)
        {
            switch (e.Key)
            {
                case Key.N:
                    MenuCommands.NewProject.Execute(NewProjectMenuItem);
                    break;
            }
        }
    }
