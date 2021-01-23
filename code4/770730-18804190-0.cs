    meh = Console.ReadLine();
            if (meh.ToString().IndexOf("!") != -1)
                meh.Replace("!", "");
            else
            {
                bleh.Remove(0, 1);
                meh.Replace("^", "");
            }
    bleh.Append(meh);
