    private void ReadResponse(IAsyncResult ar)
    {
        if (!_conected)
            return;
        string payLoadId = "";
        int payLoadIndex = 0;
      try
      {
        var info = ar.AsyncState as MyAsyncInfo;
        info.MyStream.ReadTimeout = 100;
        if (_apnsStream.CanRead)
        {
          var command = Convert.ToInt16(info.ByteArray[0]);
          var status = Convert.ToInt16(info.ByteArray[1]);
          var ID = new byte[4];
          Array.Copy(info.ByteArray, 2, ID, 0, 4);
          payLoadId = Encoding.Default.GetString(ID);
          payLoadIndex = ((int.Parse(payLoadId)) - 1000);
          Logger.Error("Apple rejected palyload for device token : " + _notifications[payLoadIndex].DeviceToken);
          Logger.Error("Apple Error code : " + _errorList[status]);
          Logger.Error("Connection terminated by Apple.");
          _rejected.Add(_notifications[payLoadIndex].DeviceToken);
          _conected = false;
        }
      }
      catch (Exception ex)
      {
          Logger.Error("An error occurred while reading Apple response for token {0} - {1}", _notifications[payLoadIndex].DeviceToken, ex.Message);
      }
    }
