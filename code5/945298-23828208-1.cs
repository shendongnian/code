    [TestMethod]
    [TestCategory("ConfigTool")]
    public async Task CancelChangesTest()
    {
      string storexaml =   this._target.Incident.WorkflowXamlString;
      this._target.Incident.WorkflowXamlString = "dsdfsdgfdsgdfgfd";
      var cancelChanges = await  this._target.CancelChanges();
      Assert.IsTrue(storexaml == this._target.Incident.WorkflowXamlString);
      Assert.IsFalse(this._target.HaveChanges);
    }
