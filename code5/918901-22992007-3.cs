        public static void ResizeTiff(string SourceFile, string DestinationFile, float ResolutionWidth, float ResolutionHeight, Guid ProcessId)
        {
            var directory = GDalBin;
            var exe = Path.Combine(directory, "gdalwarp.exe");
            var args = " -ts " + ResolutionWidth + " " + ResolutionHeight + " -r cubic -co \"TFW=YES\" \"" + SourceFile + "\" \"" + DestinationFile + "\"";
            float progress = 0;
            Action<string, string> callback = delegate(string fullOutput, string newOutput)
            {
                float value;
                if (float.TryParse(newOutput, out value))
                    progress = value;
                else if (newOutput == ".")
                    progress += 2.5f;
                else if (newOutput.StartsWith("100"))
                    progress = 100;
            };
            ExecuteProcess(exe, args, null, directory, 0, null, true, true, 0, callback);
        }
