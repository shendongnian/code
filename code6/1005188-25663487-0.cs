         public string ExecuteCommand(string command) {
         //   Thread tmp = new Thread(new ParameterizedThreadStart(WorkThread));
         //   tmp.Start(command);
        //    tmp.Join();
          //  return SharedBuilder.ToString();
            if (OctaveProcess.HasExited)
            {
                OctaveProcess.Start();
            }
            SharedBuilder.Clear();
            if (command != null)
            {
                OctaveProcess.StandardInput.WriteLine(command);
                OctaveDoneEvent.Reset();
                OctaveDoneEvent.WaitOne();
                return SharedBuilder.ToString();
            }
            Octave octave = new Octave(@"c:\software\Octave-3.6.4",false);
            octave.ExecuteCommand("a=[1,2;3,4];");
            octave.ExecuteCommand("result=a;");
            double[][] m = octave.GetMatrix("result");
            //**** The Error is here *****
            //return a string here 
        }
