    public void VerifyContract(Action action) { 
      bool failed = false;
      bool thrown = false;
      EventHandler e = (sender, e) => { failed = true; }
      Contract.ContractFailed += e;
      try { 
        action();
      } catch (Execption) {
        Assert.True(failed);
        thrown = true;
      } finally {
        Contract.ContractFailed -= e;
      }
      Assert.True(thrown);
    }
    
  
