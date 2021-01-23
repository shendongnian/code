    if (wrong > 0 && wrong <= 100)
    {
        array[i] = wrong;
    }
    else if(wrong < 0 || wrong >= 100)
    {
         Console.WriteLine("Wrong input:");
         wrong = Keyboard.ReadInt();
    }
