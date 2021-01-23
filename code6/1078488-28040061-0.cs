    Action<int, Action<Control, Control>> loop = (int stop, Action<Control, Control> action) =>
    {
        for (int i = 0; i < stop; i++)
        {
            for (int j = 0; j < stop; j++)
            {
                //// invoke action with real parameters
                // action(controlParent, controlChild);
            }
        }
    };
    Action<Control, Control> Add = (Control Parent, Control Child) => Parent.Controls.Add(Child);
    loop(1, Add);
