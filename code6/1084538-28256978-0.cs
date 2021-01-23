           private string startingDegree;    
           private void Myo_OrientationDataAcquired(object sender, OrientationDataEventArgs e)
        {
           App.Current.Dispatcher.Invoke((Action)(() =>
            {
                //need to record degree reading when pose made that
                //signifies begining of painful arc.
                //then specify a second pose that signals the end of
                //painful arc and store arc reading, eg 92dg - 108dg
                //myo indicator must be facing down or degrees will be inverted.
                degreeOutput = ((e.Pitch + PITCH_MIN) * CALLIBRATION_FACTOR);
                degreeOfAbductionTbx.Text = "Degree: " + degreeOutput;
                if(e.Myo.Pose == Pose.Fist)
                {
                   if(string.IsNullOrEmpty(startingDegree))
                    {
                        startingDegree = "start: " + degreeOutput;
                    }
                    //get the start reading of the painful arc
                    painfulArcStartTbx.Text = startingDegree;
                }
                //then get the finish reading of the painful arc
                //after the fist pose has been let go, indicating
                //end of pain in movement
                else
                {
                    startingDegree = string.Empty;
                    painfulArcEndTbx.Text = "end: " + degreeOutput;
                }
            })); 
        }
