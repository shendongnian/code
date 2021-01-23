	public void CPUStats() {
		var cpuCounter= .. 
		... 
		MethodInvoker m=() => {
			try {
				cpuLabel.Text="CPU: "+cpusage.Remove(cpusage.IndexOf('.'))+"%";
			}
			catch(ArgumentOutOfRangeException) {
				cpuLabel.Text="CPU: "+cpusage+"%";
			}
		};
		cpuLabel.Invoke(m);
		... 
	}
