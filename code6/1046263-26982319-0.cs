    public Boolean Execute( KeyboardCommand _command, Boolean _first, Boolean _last, Boolean _keyDown )
        {
          if (_keyDown)
              {
                switch (_command)
                {
                  case (KeyboardCommand.otherCommand):
                    handled = ExecuteCommand();
                    break;
                }
              }
          switch (_command)//Short press and long press events
              {
                case (KeyboardCommand.mycommand):
                    if (_first)
                    {
                      m_TimeKeyDown = DateTime.Now;
                      m_LongCommandExecuted = false;
                    }
                    else
                    {
                      TimeSpan timeLapse = DateTime.Now - m_TimeKeyDown;
                      if (!m_LongCommandExecuted && timeLapse.TotalMilliseconds > 500)//long press
                      {
                        m_LongCommandExecuted = true;
                        handled = myLongcommand();
                      }
    
                      if (!m_LongCommandExecuted && _last)//short press
                      {
                        m_LongCommandExecuted = true;
                        handled = myShortcommand();
                      }
                    }
                    break;
              } 
       //some other jazz         
    
    }
