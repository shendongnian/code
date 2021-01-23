    void OnEnable(){
        Debug.Log ("OnEnable");
        EasyJoystick.On_JoystickMoveStart += HandleOn_JoystickMoveStart;
        EasyJoystick.On_JoystickMove += HandleOn_JoystickMove;
        EasyJoystick.On_JoystickMoveEnd += HandleOn_JoystickMoveEnd;
    }
