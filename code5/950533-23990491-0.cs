    public string update()
    		{
    			string[] sMsg = msg.Split(new Char[]{'\n'});
    
    			string[] finalmsg = sMsg[0].Split(new Char[]{':'});
    
    			if ((finalmsg.Length != 8 && sMsg[0] == msg) || sMsg.Length < 2)
    			{ // not finished reading 
    				//Debug.WriteLine("\n\n--skip as the size is : " + finalmsg.Length);
    				return null;
    			}
    
    			msg = msg.Substring(sMsg[0].Length+2,msg.Length-(sMsg[0].Length+2));
    			if (finalmsg.Length >= 8){
    
    				Dispatcher.BeginInvoke(delegate()
    					{
    						string[] fm = finalmsg;
    						RX.Text = finalmsg[0];
    						RY.Text = finalmsg[1];
    						LX.Text = finalmsg[2];
    						LY.Text = finalmsg[3];
    						RF1.Text = finalmsg[4];
    						RF2.Text = finalmsg[5];
    						LF1.Text = finalmsg[6];
    						LF2.Text = finalmsg[7];
    					});	            				
    			}
    
    			return finalmsg[0];
    		}
