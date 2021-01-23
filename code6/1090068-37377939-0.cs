    private static void Skype_ContactsFocused(string Username)
    {
        //Console.WriteLine("Skype_ContactsFocused is {0}", Username);
        Console.WriteLine("Skype_ContatsFocused is " + ((m_skype.ActiveChats[1].Topic != "") ? m_skype.ActiveChats[1].Topic : m_skype.ActiveChats[1].FriendlyName));
    }
