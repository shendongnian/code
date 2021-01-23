    static void Main(string[] args)
    {
        var sprite = new Sprite();
        SpriteMemento state = null;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "run")
                sprite.Run();
            else if (input == "save")
                state = sprite.Memento;
            else if (input == "undo")
                sprite.Restore(state);
            sprite.Render();
        }
    }
