    public void MyClickHandler()
    {
        ChangeState();
    }
    private void ChangeState()
    {
    Switch (_lastState)
     
    case "Red": _lastState = "Yellow";
                _myControl.Backgroung = Yellow;
    case "Yellow": _lastState = "Green";
                _myControl.Backgroung = Green;
    
    .. and so on..
    
    }
    where _myControl is your state .. may be just a string variable..
    }
 
 
