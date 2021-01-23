    private int pitch;
    private void Myo_OrientationDataAcquired(object sender, OrientationDataEventArgs e)
    {
        const float PI = (float)System.Math.PI;
        pitch = (int)((e.Pitch + PI) / (PI * 2.0f) * 10);
    }
    private void Pose_Triggered(object sender, PoseEventArgs e)
    {
        App.Current.Dispatcher.Invoke((Action)(() =>
        {
            poseStatusTbx.Text = "{0} arm Myo holding pose {1}" + e.Myo.Arm + e.Myo.Pose;
            //error trying to reference pitch here.
            pitch = pitchDefault;
        }));    
    }
