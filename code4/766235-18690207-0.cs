    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Firefox;
    
    namespace TestProcess {
    	[TestClass]
    	public class UnitTest1 {
    		[TestMethod]
    		public void TestMethod1() {
    			IEnumerable<int> pidsBefore = Process.GetProcessesByName("firefox").Select(p => p.Id);
    
    			FirefoxDriver driver = new FirefoxDriver();
    			IEnumerable<int> pidsAfter = Process.GetProcessesByName("firefox").Select(p => p.Id);
    
    			IEnumerable<int> newFirefoxPids = pidsAfter.Except(pidsBefore);
    
    			// do some stuff with PID, if you want to kill them, do the following
    			foreach (int pid in newFirefoxPids) {
    				Process.GetProcessById(pid).Kill();
    			}
    		}
    	}
    }
