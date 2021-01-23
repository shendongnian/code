    class TestObjWithInt32
    {
    	public Int32 Int32 { get; set; }
    	public Int32? SetNullable { get; set; }
    	public Int32? UnsetNullable { get; set; }
    }
    [TestMethod]
    public void IsApplied_When_Int32IsDeserializedToPatchable()
    {
    	string testData = "{\"Int32\":1,\"SetNullable\":1}";
    	var deserializedPatchable = JsonConvert.DeserializeObject<Patchable<TestObjWithInt32>>(testData);
    	var result = deserializedPatchable.ChangedPropertyNames.Contains("Int32");
    	Assert.IsTrue(result);
    	var patchedObject = new TestObjWithInt32();
    	Assert.AreEqual<Int32>(0, patchedObject.Int32);
    	deserializedPatchable.Patch(patchedObject);
    	Assert.AreEqual<Int32>(1, patchedObject.Int32);
    	Assert.IsNull(patchedObject.UnsetNullable);
    	Assert.IsNotNull(patchedObject.SetNullable);
    }
