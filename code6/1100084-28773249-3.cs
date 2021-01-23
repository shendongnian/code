    Enum class EnumAction
    {
      Nothing,
      Run,
      bark,
      exit,
    };
    EnumAction m_enAction;
    Object m_oLockAction;
    void SetAction (EnumAction i_enAction)
    {
      Monitor.Enter (m_oLockAction);
      m_enAction = i_enAction;
      Monitor.Exit (m_oLockAction);
    }
    void SetAction (EnumAction i_enAction)
    {
      Monitor.Enter (m_oLockAction);
      m_enAction = i_enAction;
      Monitor.Exit (m_oLockAction);
    }
    Void doActions()
    {
      EnumAction enAction;
      Do
      {
        Thread.sleep(20);
        enAction = GetAction();
        Switch(enAction)
        {
        Case EnumAction.run:
          Run(); break;
        Case ...
        }
      } while (enAction != EnumAction.exit);
    }
