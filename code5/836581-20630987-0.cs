        int index = _StartTime.IndexOf("M");
        if (index >= 0) 
    {
    _StartTime = _StartTime.Substring(0, index-1);
    switch (_StartTime.IndexOf("P"))
    case : -1
     _StartTime = _StartTime.Substring(0,_StartTime.Length);
     break;
    
    default:
     string hours = _startTime.Substring(_StartTime.Length-8,2);
     int H = Convert.ToInt32(hours);
     H += 12;
     string result = _StartTime.Substring(0, _StartTime.Length-8)+ Convert.ToString(H)+_startTime.Substring(_StartTime.Length-6);
    
    _StartTime = result;
    break;
    }
    
