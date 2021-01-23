PM> Install-Package AutoFixture.Xunit
Although I haven't tried to compile this, the example test could be rewritten as:
    [Theory, TestConventions]
    public void Should_not_set_the_temp_data_when_the_model_is_valid(
        ActionExecutedContext context,
        ExportModelStateToTempDataAttribute attribute)
    {
        attribute.OnActionExecuted(context);
        context.Controller.TempData.Should().HaveCount(0);
    }
Where `TestConventions` is defined as:
    internal class TestConventionsAttribute : AutoDataAttribute
    {
        internal TestConventionsAttribute() 
            : base(
                new Fixture()
                    .Customize(new CustomActionResult<RedirectResult>(
                                   "Controller/Action"))
                    .Customize(new CustomController())
                    .Customize(new CustomActionExecutedContext()))
        {
        }
    }
