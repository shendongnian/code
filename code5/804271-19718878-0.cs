            var cpuusageforlabel = "CPU: ";
            if (!string.IsNullOrEmpty(cpuusage)) {
                var index = cpuusage.IndexOf('.');
                if (index != -1) {
                    cpuusageforlabel += cpuusage.Remove(index);
                } else {
                    cpuusageforlabel += cpuusage;
                }
            } else {
                cpuusageforlabel += "0";
            }
            cpuusageforlabel += "%";
       cpuLabel.Invoke((MethodInvoker)(() => cpuLabel.Text = cpuusageforlabel));
