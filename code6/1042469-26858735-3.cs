    [TestMethod]
    public void HtmlHelperExtentions_Translate_WithValidInputs_ReturnsTranslatedContent()
    {
        // Arrange          
        var defaultstring = "TestMessage";
        var inputkey = "XX.Areas.Onboarding.{0}Messages.Message_Onboarding_XX_1001";
        var expectedvalue = "HolaMessage";
        HtmlHelper htmlhelper = null;
        contextBase.Setup(ctx => ctx.GetGlobalResourceObject(null, inputkey)).Returns(expectedvalue);
        //Act
        var result = HtmlHelperExtentions.Translate(htmlhelper, contextBase.Object, defaultstring, inputkey);
        //Assert            
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedvalue, result.ToString());
    }
