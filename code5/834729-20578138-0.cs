    void DoAction1( Dictionary<string,string> dict )
    {
      // perform action 1
    }
    void DoAction2( Dictionary<string,string dict )
    {
      // perform action 2
    }
    Dictionary<string,string> _deliveryType = GetDeliveryType() ;
    if (_deliveryType.ContainsKey(fileName))
    {
      if (contactPreference == SAMPLE_ENUM)
      {
        DoAction1(_deliveryType) ; 
      }
      else
      {
        DoAction2(_deliveryType) ;
      }
    }
    else
    {
      DoAction2(_deliveryType) ;
    }
