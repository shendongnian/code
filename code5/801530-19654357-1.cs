        [Fact]
        public void Should_Call_SubmissionVersionRemoveStepsOnce()
        {
            // Arrange
            var ctx = new TestContext();
            ctx
                .SubmissionVersion
                .SetupGet(x => x.Steps)
                .Returns(new List<Step> { ctx.Step });
            var submissionVersion = ctx.SubmissionVersion.Object;
            ctx.SubmissionVersion.Setup(x => x.Steps.Remove(It.IsAny<Step>()));
            // Act
            submissionVersion.DeleteStep(
                ctx.Repository.Object,
                ctx.SubmissionVersion.Object,
                ctx.Step.Id.Value);
            // Assert
            ctx
                .SubmissionVersion
                .Verify(x => x.Steps.Remove(It.IsAny<Step>()), Times.Once());
        }
