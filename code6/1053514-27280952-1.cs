            if (this.iisProcess == null) throw new Exception("Does not look like there was something started yet!");
            if (this.iisProcess.HasExited)
            {
                log.WarnFormat("IIS has already exited with code '{0}'", this.iisProcess.ExitCode);
                this.iisProcess.Close();
                return;
            }
            log.InfoFormat("Stopping IIS instance #{0}", this.instanceId);
            ProcessCommunication.SendStopMessageToProcess(this.iisProcess.Id);
            bool exited = this.iisProcess.WaitForExit(30000);
            if (!exited)
            {
                log.WarnFormat("Failed to stop IIS instance #{0} (PID {1}), killing it now", this.instanceId, this.iisProcess.Id);
                this.iisProcess.Kill();
            }
            this.iisProcess.Close();
