    // If Enter was just pressed, move into the submenu if it exists
    if (m_CurrentState.IsKeyUp(Keys.Enter) && m_PreviousState.IsKeyDown(Keys.Enter))
    {
        // If we are currently hovering over options, we should move into that submenu
        if (m_CurrentMenuOption == MenuOptions.OPTIONS)
        {
            // Make sure to reset all other bools like this if you have any to avoid
            // confusing bugs later
            m_InOptions = true;
        }
    }
    // If Down was pressed, move the enum value we store
    else if (m_CurrentState.IsKeyUp(Keys.Down) && m_PreviousState.IsKeyDown(Keys.Down))
    {
        // Check to see if we are in options submenu so we can move that value rather than 
        // the main menu's value
        if (m_InOptions)
        {
            m_CurrentOptionsOption++;
            // Checks to see if you went further than the last option and sets it to the
            // last option if you did
            if ((int)m_CurrentOptionsOption >= (int)OptionsOptions.MAX)
                m_CurrentOptionsOption = OptionsOptions.RAISE_LOWER_VOLUME;
        }
        else // You could add some else ifs before for other sub menus
        {
            // Since we are not in a submenu, update the current menu option
            m_CurrentMenuOptions++;
            
            // Checks to see if you went further than the last option and sets it to the
            // last option if you did
            if ((int)m_CurrentMenuOptions >= (int)MenuOptions.MAX)
                m_CurrentMenuOption = MenuOptions.QUIT;
        }
    }
    // If Up was pressed, move the enum value we store
    else if (m_CurrentState.IsKeyUp(Keys.Up) && m_PreviousState.IsKeyDown(Keys.Up))
    {
        // Check to see if we are in options submenu so we can move that value rather than
        // the main menu's value
        if (m_InOptions)
        {
            m_CurrentOptionsOption--;
            // Checks to see if you went further than the first option and sets it to the
            // first option if you did
            if ((int)m_CurrentOptionsOption <= (int)OptionsOptions.MIN)
                m_CurrentOptionsOption = OptionsOptions.MUTE_SOUND;
        }
        else // You could add some else ifs before for other sub menus
        {
            // Since we are not in a submenu, update the current menu option
            m_CurrentMenuOptions--;
            
            // Checks to see if you went further than the first option and sets it to the
            // first option if you did
            if ((int)m_CurrentMenuOptions <= (int)MenuOptions.MIN)
                m_CurrentMenuOption = MenuOptions.PLAY;
        }
    }
    // If Backspace was pressed, move back a menu if possible
    else if (m_CurrentState.IsKeyUp(Keys.Back) && m_PreviousState.IsKeyDown(Keys.Back))
    {
        if (m_InOptions) // you would tack on some || or else ifs for any other submenus
        {
            m_InOptions = false;
        }
    }
