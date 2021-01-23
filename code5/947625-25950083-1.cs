    using (var rs = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspace()) {
    	rs.Open();
    
    	using (var ps = PowerShell.Create()) {
    		ps.Runspace = rs;
    
    		var assembly = System.Reflection.Assembly.GetExecutingAssembly();
    		var scriptName = "LabManagement.Scripts.GetVirtualMachineStatus.ps1";
    
    		using (var s = assembly.GetManifestResourceStream(scriptName)) {
    			using (var reader = new System.IO.StreamReader(s)) {
    				var script = reader.ReadToEnd();
    
    				ps.AddScript(script);
    			}
    		}
    
    		ps.Runspace.SessionStateProxy.SetVariable("vmmHostname", this.ServerName);
    		ps.Runspace.SessionStateProxy.SetVariable("hostname", hostname);
    
    		var output = ps.Invoke();
    
    		...
    		// process output and errors
    		...
    
    			rs.Close();
    		}
    		else {
    			rs.Close();
    		}
    	}
    }
