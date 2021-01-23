    [TestMethod]
    public void GetForm()
    {
        Form frm = new Form();
        Assert.AreEqual(2, frm.Items.Count);
        Assert.AreEqual("User ID", frm.Items[0].Text);
        ...
    }
