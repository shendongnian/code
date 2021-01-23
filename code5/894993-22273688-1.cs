    private void WaveFormLoop(CancellationToken cancelToken)
    {
            try
            {
                while(someCondition) //Replace this with your real loop structure, I had to guess
                {
                    cancelToken.ThrowIfCancellationRequested();
                    Thread.Sleep(1000); //Fake doing work
                    cancelToken.ThrowIfCancellationRequested();
                    Thread.Sleep(1000); //Fake doing more work
                }
            }
            catch (OperationCanceledException) 
            {
                //Draw intitial Waveform
                ResetWaveForm();
            }
    }
