    [Test]
    public void test_controller_with_model_error()
    {
        var controller = new PosController();
        controller.ModelState.AddModelError("test", "test");
        ActionResult result = posController.Index(new PosViewModel());
        // Assert that the controller executed the right actions when the model is invalid
    }
