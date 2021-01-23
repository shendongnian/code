    [TestClass]
    public class Tests
    {
         [TestMethod]
         private void ValidateTestOne(EntityModel.MultiIndexEntites  context)
         {
              Assert.AreEqual(expectedEntityCount, context.Entities.Count(), "Entity Count was different from what was expected");
         }
    }
