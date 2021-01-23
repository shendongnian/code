    UnsignedMixerControl volumeControl;
    int waveInDeviceNumber = 0;
    var mixerLine = new MixerLine((IntPtr)waveInDeviceNumber, 
                                   0, MixerFlags.WaveIn);
    foreach (var control in mixerLine.Controls)
    {
        if (control.ControlType == MixerControlType.Volume)
        {
            volumeControl = control as UnsignedMixerControl;        
            break;
        }
    }
    volumeControl.Percent = 30; // you are setting volume here, as a percentage.
