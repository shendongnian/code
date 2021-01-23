        private int _workStep;
        private void button1_Click(object sender, EventArgs e)
        {
            _workStep = 0;
            timerWork.Start();
        }
        private void timerWork_Tick(...)
        {
             switch(workStep)
             {
                 case 0:
                     ... // do something
                     if(something)
                         _workStep = 1;
                 case laststep:
                     timerWork.Stop();
             }
        }
