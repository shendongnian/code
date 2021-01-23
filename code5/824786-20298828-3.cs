    private void StatusTimer_Tick(object sender, EventArgs e)
            {
                if (status == true)
                {                
                        mes = "GruppoDue:ON!";
                        send.Send(Encoding.ASCII.GetBytes(mes), mes.Length, "192.168.7.255", 11000);                 
                }
                else
                {              
                        mes = "GruppoDue:OFF!";
                        send.Send(Encoding.ASCII.GetBytes(mes), mes.Length, "192.168.7.255", 11000);
                }
                  //StatusTimer.Start();//remove or comment
