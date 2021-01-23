    [TestMethod]
    [TestCategory("ConfigTool")]
    public void CancelChangesTest()
    {
        string storexaml = this._target.Incident.WorkflowXamlString;
        this._target.Incident.WorkflowXamlString = "dsdfsdgfdsgdfgfd";
        this._target.CancelChanges().ContinueWith(ant => 
            {
                Assert.IsTrue(storexaml == this._target.Incident.WorkflowXamlString);
                Assert.IsFalse(this._target.HaveChanges);
            });
    }
    
