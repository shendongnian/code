            catch
            {
                if (disconnectionType == BattlEyeDisconnectionType.ConnectionLost)
                {
                    Disconnect(BattlEyeDisconnectionType.ConnectionLost);
                    Connect();
                    return BattlEyeConnectionResult.ConnectionFailed;
                }
                else
                {
                    OnConnect(loginCredentials, BattlEyeConnectionResult.ConnectionFailed);
                    return BattlEyeConnectionResult.ConnectionFailed;
                }
            }
