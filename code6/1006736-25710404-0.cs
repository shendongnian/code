    private bool isArduinoFree=true;
    private int _timeOut=500; //equal to half second
     private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isArduinoFree)
               {
                isArduinoFree=false;
                switch (e.KeyCode)
                {
                    case Keys.W:
                        Arduino.Write("R");
                        break;
                    case Keys.S:
                        Arduino.Write("A");
                        break;
                    case Keys.A:
                        Arduino.Write("I");
                        break;
                    case Keys.D:
                        Arduino.Write("S");
                        break;
                }
                Thread.Sleep(_timeOut);
                _isArduinoFree=true;
               }
       }
