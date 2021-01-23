    private bool SendMessage()
    {
       try
       {
          Data mailToBeSent = new Data();            
          mailToBeSent.cmdCommand = Command.Message;
          mailToBeSent.ipAddress = _client.IpAddress; 
          mailToBeSent.strMessage = tbMsg.Text;      
          _client.Send(mailToBeSent, 0, 1000);       
          tbMsg.Text = string.Empty;                         
        }
        catch (Exception)
        {
           return false;
        }
        return true;
    }
