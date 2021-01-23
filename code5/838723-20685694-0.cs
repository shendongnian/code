        private void EditorSetCommand_KeyDown(object sender, KeyEventArgs e)
        {
            MyType g = (MyType)TheEditor.DataContext;
            Key k = e.Key;
            g.Command.Add(e.Key);
            g.Command = g.Command;
            RemoveHandler(Keyboard.KeyDownEvent, (KeyEventHandler)EditorSetCommand_KeyDown);
        }
